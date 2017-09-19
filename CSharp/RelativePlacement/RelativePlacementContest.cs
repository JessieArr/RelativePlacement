using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelativePlacement
{
    public class RelativePlacementContest
    {
        public string ContestName { get; }
        public IList<Contestant> Contestants { get; }
        public IList<Judge> Judges { get; }
        public Judge HeadJudge { get; private set; }

        public RelativePlacementContest(string contestName)
        {
            ContestName = contestName;
            Contestants = new List<Contestant>();
            Judges = new List<Judge>();
        }

        public void SetHeadJudge(Judge headJudge)
        {
            if (HeadJudge != null)
            {
                throw new RelativePlacementException($"Head Judge {HeadJudge.DisplayName} is already part of this contest!");
            }
            if (headJudge == null)
            {
                throw new ArgumentNullException(nameof(headJudge));
            }

            HeadJudge = headJudge;
        }

        public void AddContestant(Contestant newContestant)
        {
            if (newContestant == null)
            {
                throw new ArgumentNullException(nameof(newContestant));
            }
            Contestants.Add(newContestant);
        }

        public void AddJudge(Judge newJudge)
        {
            if (newJudge == null)
            {
                throw new ArgumentNullException(nameof(newJudge));
            }
            Judges.Add(newJudge);
        }

        public void JudgeContest()
        {
            if (HeadJudge == null)
            {
                throw new RelativePlacementException("Head judge must be specified!");
            }
            if (Judges.Count % 2 != 1)
            {
                throw new RelativePlacementException("Number of judges must be odd!");
            }

        }
    }
}
