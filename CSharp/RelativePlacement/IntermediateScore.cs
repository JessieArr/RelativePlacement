namespace RelativePlacement
{
    public class IntermediateScore
    {
        public Contestant Contestant;
        public int Placement;
        /// <summary>
        /// Number of judges who placed this Contestant at or below the specified placement.
        /// </summary>
        public int RelativePlacementCountAtOrBelowPlacement;

        /// <summary>
        /// Sum of placement values at or below the given placement. e.g. three 2nd places and
        /// a 1st place would be 2 + 2 + 2 + 1 = 7 when calculating for Placement = 2.
        /// </summary>
        public int RelativePlacementSum;

        public IntermediateScore(Contestant contestant, int placement, int relativePlacementCountAtOrBelowPlacement, int relativePlacementSum)
        {
            Contestant = contestant;
            Placement = placement;
            RelativePlacementCountAtOrBelowPlacement = relativePlacementCountAtOrBelowPlacement;
            RelativePlacementSum = relativePlacementSum;
        }
    }
}