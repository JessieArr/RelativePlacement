namespace RelativePlacement
{
    public class RawScore
    {
        public Judge Judge;
        public Contestant Contestant;
        public double Score;

        public RawScore(Judge judge, Contestant contestant, double score)
        {
            Judge = judge;
            Contestant = contestant;
            Score = score;
        }
    }
}