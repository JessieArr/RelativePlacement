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

        public IList<RawScore> RawScores { get; }
        public IList<RelativeScore> RelativeScores { get; }


        public RelativePlacementContest(string contestName)
        {
            ContestName = contestName;
            Contestants = new List<Contestant>();
            Judges = new List<Judge>();
            RawScores = new List<RawScore>();
            RelativeScores = new List<RelativeScore>();
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

        public void AddRawScore(Judge judge, Contestant contestant, double rawScore)
        {
            if (judge == null)
            {
                throw new ArgumentNullException(nameof(judge));
            }
            if (contestant == null)
            {
                throw new ArgumentNullException(nameof(contestant));
            }
            RawScores.Add(new RawScore(judge, contestant, rawScore));
        }

        public RelativePlacementContestResult JudgeContest()
        {
            if (HeadJudge == null)
            {
                throw new RelativePlacementException("Head judge must be specified!");
            }
            if (Judges.Count % 2 != 1)
            {
                // Because Relative Placement Scoring relies on establishing majorities to 
                // rank contestants, the number of judges must be odd for the algorithm to work.
                throw new RelativePlacementException("Number of judges must be odd!");
            }

            GetRelativeScores();

            return new RelativePlacementContestResult();
        }

        private void GetRelativeScores()
        {
            foreach (var judge in Judges)
            {
                var judgeRawScores = RawScores.Where(x => x.Judge == judge).ToList();
                var relativeScores = GetJudgeRelativeScores(judgeRawScores);
                foreach (var score in relativeScores)
                {
                    RelativeScores.Add(score);
                }
            }
        }

        private IList<RelativeScore> GetJudgeRelativeScores(List<RawScore> judgeScores)
        {
            var relativeScores = new List<RelativeScore>();
            var orderedScores = judgeScores.OrderByDescending(x => x.Score);
            var i = 1;
            foreach (var score in orderedScores)
            {
                relativeScores.Add(new RelativeScore(i, score.Judge, score.Contestant));
                i++;
            }

            return relativeScores;
        }
    }
}
