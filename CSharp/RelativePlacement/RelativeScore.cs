namespace RelativePlacement
{
    public class RelativeScore
    {
        public int OrdinalPlace { get; }
        public Judge Judge { get; }
        public Contestant Contestant { get; }

        public RelativeScore(int ordinalPlace, Judge judge, Contestant contestant)
        {
            OrdinalPlace = ordinalPlace;
            Judge = judge;
            Contestant = contestant;
        }
    }
}