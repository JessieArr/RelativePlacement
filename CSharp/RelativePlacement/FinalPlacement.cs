using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelativePlacement
{
    public class FinalPlacement
    {
        public int Place;
        public Contestant Contestant;
        public int AwardedInRound;
        public PlacementTypeEnum PlacementType;
        public string ExplanationOfPlacement;

        /// <summary>
        /// In the event that multiple contestants in a given placement round have a majority,
        /// a tiebreaking algorithm is used to place them relative to each other. This contestant
        /// was placed ahead of the other contestants in this list for their round.
        /// </summary>
        public List<Contestant> AwardedPlaceAheadOfContestants;

        /// <summary>
        /// In the event that multiple contestants in a given placement round have a majority,
        /// a tiebreaking algorithm is used to place them relative to each other. This contestant
        /// was placed behind the other contestants in this list for their round.
        /// </summary>
        public List<Contestant> AwardedPlaceBehindContestants;

        public FinalPlacement()
        {
            AwardedPlaceAheadOfContestants = new List<Contestant>();
            AwardedPlaceBehindContestants = new List<Contestant>();
        }
    }
}
