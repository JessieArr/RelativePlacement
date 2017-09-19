using System.Collections.Generic;
using System.Linq;

namespace RelativePlacement
{
    public class Judge
    {
        public string DisplayName;
        public IList<RawScore> Scores;

        public void GetRelativeScores()
        {
            var relativeScores = new List<RelativeScore>();
            var orderedScores = Scores.OrderByDescending(x => x.Score);
            var ordinal = 1;
            foreach (var score in orderedScores)
            {
                relativeScores.Add(new RelativeScore(ordinal, this, score.Contestant));
                ordinal++;
            }
        }
    }
}