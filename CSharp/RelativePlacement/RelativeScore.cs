namespace RelativePlacement
{
    public class RelativeScore
    {
        public Judge Judge { get; }
        public Contestant Contestant { get; }
        public int OrdinalPlace { get; }

        public RelativeScore(int ordinalPlace, Judge judge, Contestant contestant)
        {
            OrdinalPlace = ordinalPlace;
            Judge = judge;
            Contestant = contestant;
        }
    }
}