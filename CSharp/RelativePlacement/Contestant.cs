using System.Collections.Generic;

namespace RelativePlacement
{
    public class Contestant
    {
        public string DisplayName;
        public IList<RelativeScore> RelativeScores;

        public Contestant(string displayName)
        {
            DisplayName = displayName;
        }
    }
}