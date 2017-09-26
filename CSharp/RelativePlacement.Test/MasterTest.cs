using System;
using System.Collections.Generic;
using Xunit;

namespace RelativePlacement.Test
{
    /// <summary>
    /// This class contains tests according to the example provided in the document
    /// "Unraveling the Mystery of the RELATIVE PLACEMENT SCORING SYSTEM" by Jim Tigges
    /// published by the WSDC as a resource for those learning about Relative Placement
    /// Scoring.
    /// </summary>
    public class MasterTest
    {
        private RelativePlacementContest _SUT;
        private RelativePlacementContestResult _Result;

        private List<List<double>> _TestScores = new List<List<double>>()
        {
            new List<double>() {8.75, 8.63, 8.85, 9.0, 8.69, 8.6, 9.1, 8.64, 8.9, 8.65, 8.4, 8.67}, // Judge 1
            new List<double>() {8.0, 8.6, 8.25, 8.38, 8.3, 8.1, 8.35, 8.2, 8.5, 8.32, 8.23, 8.15}, // Judge 2
            new List<double>() {9.34, 9.2, 9.33, 9.35, 9.31, 9.65, 9.7, 9.25, 9.72, 9.32, 9.28, 9.45}, // Judge 3
            new List<double>() {7.7, 8.6, 7.9, 9.0, 8.5, 7.8, 8.8, 7.95, 8.2, 8.25, 7.75, 8.3}, // Judge 4
            new List<double>() {9.1, 9.15, 9.2, 9.6, 9.5, 9.3, 8.7, 9.25, 9.4, 8.6, 8.65, 9.12}, // Judge 5
            new List<double>() {7.0, 7.2, 7.6, 8.5, 7.24, 7.1, 7.15, 7.25, 8.6, 7.4, 7.05, 7.3}, // Judge 6
            new List<double>() {8.3, 8.8, 9.0, 9.5, 8.6, 8.1, 9.4, 8.5, 9.6, 8.9, 7.9, 9.2}, // Judge 7
        };

        private List<double> _TestHeadJudgeScores = new List<double>()
        {
            8.9, 9.1, 8.7, 9.4, 9.0, 8.0, 9.3, 8.6, 9.5, 8.8, 8.4, 9.2
        };

        private List<Contestant> _TestContestantList = new List<Contestant>();
        private List<Judge> _TestJudgeList = new List<Judge>();

        public MasterTest()
        {
            _SUT = new RelativePlacementContest("Test Competition");

            _SUT.SetHeadJudge(new Judge("Chief Judge"));

            var judge1 = new Judge("Judge #1");
            var judge2 = new Judge("Judge #2");
            var judge3 = new Judge("Judge #3");
            var judge4 = new Judge("Judge #4");
            var judge5 = new Judge("Judge #5");
            var judge6 = new Judge("Judge #6");
            var judge7 = new Judge("Judge #7");

            _TestJudgeList.Add(judge1);
            _TestJudgeList.Add(judge2);
            _TestJudgeList.Add(judge3);
            _TestJudgeList.Add(judge4);
            _TestJudgeList.Add(judge5);
            _TestJudgeList.Add(judge6);
            _TestJudgeList.Add(judge7);

            _SUT.Judges.Add(judge1);
            _SUT.Judges.Add(judge2);
            _SUT.Judges.Add(judge3);
            _SUT.Judges.Add(judge4);
            _SUT.Judges.Add(judge5);
            _SUT.Judges.Add(judge6);
            _SUT.Judges.Add(judge7);

            var romieAndJulie = new Contestant("Romie & Julie");
            var marcAndCleo = new Contestant("Marc & Cleo");
            var georgeAndGracie = new Contestant("George & Gracie");
            var jackAndAnnie = new Contestant("Jack & Annie");
            var rhettAndScarlett = new Contestant("Rhett & Scarlett");
            var rockyAndAdrian = new Contestant("Rocky & Adrian");
            var fredAndGinger = new Contestant("Fred & Ginger");
            var barneyAndBetty = new Contestant("Barney & Betty");
            var rickyAndLucy = new Contestant("Ricky & Lucy");
            var kenAndBarbie = new Contestant("Ken & Barbie");
            var ikeAndMamie = new Contestant("Ike & Mamie");
            var wardAndJune = new Contestant("Ward & June");

            _TestContestantList.Add(romieAndJulie);
            _TestContestantList.Add(marcAndCleo);
            _TestContestantList.Add(georgeAndGracie);
            _TestContestantList.Add(jackAndAnnie);
            _TestContestantList.Add(rhettAndScarlett);
            _TestContestantList.Add(rockyAndAdrian);
            _TestContestantList.Add(fredAndGinger);
            _TestContestantList.Add(barneyAndBetty);
            _TestContestantList.Add(rickyAndLucy);
            _TestContestantList.Add(kenAndBarbie);
            _TestContestantList.Add(ikeAndMamie);
            _TestContestantList.Add(wardAndJune);

            _SUT.Contestants.Add(romieAndJulie);
            _SUT.Contestants.Add(marcAndCleo);
            _SUT.Contestants.Add(georgeAndGracie);
            _SUT.Contestants.Add(jackAndAnnie);
            _SUT.Contestants.Add(rhettAndScarlett);
            _SUT.Contestants.Add(rockyAndAdrian);
            _SUT.Contestants.Add(fredAndGinger);
            _SUT.Contestants.Add(barneyAndBetty);
            _SUT.Contestants.Add(rickyAndLucy);
            _SUT.Contestants.Add(kenAndBarbie);
            _SUT.Contestants.Add(ikeAndMamie);
            _SUT.Contestants.Add(wardAndJune);

            AddTestScoresToContest();

            _Result = _SUT.JudgeContest();
        }

        private void AddTestScoresToContest()
        {
            var i = 0;
            foreach (var judge in _TestJudgeList)
            {
                var j = 0;
                foreach (var contestant in _TestContestantList)
                {
                    _SUT.AddRawScore(judge, contestant, _TestScores[i][j]);
                    j++;
                }
                i++;
            }
        }

        [Fact]
        public void RawScoreCount_IsExpected()
        {
            var expectedRawScoreCount = _SUT.Judges.Count * _SUT.Contestants.Count;
            Assert.True(_SUT.RawScores.Count == expectedRawScoreCount);
        }

        [Fact]
        public void RelativeScoreCount_IsExpected()
        {
            var expectedRelativeScoreCount = _SUT.Judges.Count * _SUT.Contestants.Count;
            Assert.True(_SUT.RelativeScores.Count == expectedRelativeScoreCount);
        }
    }
}
