using System;
using System.Collections.Generic;
using System.Linq;
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

        private Contestant romieAndJulie;
        private Contestant marcAndCleo;
        private Contestant georgeAndGracie;
        private Contestant jackAndAnnie;
        private Contestant rhettAndScarlett;
        private Contestant rockyAndAdrian;
        private Contestant fredAndGinger;
        private Contestant barneyAndBetty;
        private Contestant rickyAndLucy;
        private Contestant kenAndBarbie;
        private Contestant ikeAndMamie;
        private Contestant wardAndJune;

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

            romieAndJulie = new Contestant("Romie & Julie");
            marcAndCleo = new Contestant("Marc & Cleo");
            georgeAndGracie = new Contestant("George & Gracie");
            jackAndAnnie = new Contestant("Jack & Annie");
            rhettAndScarlett = new Contestant("Rhett & Scarlett");
            rockyAndAdrian = new Contestant("Rocky & Adrian");
            fredAndGinger = new Contestant("Fred & Ginger");
            barneyAndBetty = new Contestant("Barney & Betty");
            rickyAndLucy = new Contestant("Ricky & Lucy");
            kenAndBarbie = new Contestant("Ken & Barbie");
            ikeAndMamie = new Contestant("Ike & Mamie");
            wardAndJune = new Contestant("Ward & June");

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

        [Fact]
        public void JudgeScoreCounts_AreExpected()
        {
            foreach (var judge in _SUT.Judges)
            {
                var judgeScores = _SUT.RelativeScores.Where(x => x.Judge == judge);
                Assert.True(judgeScores.Count() == _SUT.Contestants.Count);
            }
        }

        [Fact]
        public void ContestantScoreCounts_AreExpected()
        {
            foreach (var contestant in _SUT.Contestants)
            {
                var contestantScores = _SUT.RelativeScores.Where(x => x.Contestant == contestant);
                Assert.True(contestantScores.Count() == _SUT.Judges.Count);
            }
        }

        [Fact]
        public void JudgeCountForMajority_IsExpected()
        {
            Assert.True(_SUT.JudgeCountForMajority == 4);
        }

        [Fact]
        public void AllTwelvePlacementsAreAwarded()
        {
            for (var i = 1; i <= 12; i++)
            {
                Assert.True(_SUT.FinalPlacements.Single(x => x.Place == i) != null);
            }
        }

        [Fact]
        public void JackAndAnnie_PlacedFirst()
        {
            var finalPlacement = _SUT.FinalPlacements.Single(x => x.Contestant == jackAndAnnie);
            Assert.Equal(finalPlacement.Place, 1);
        }

        [Fact]
        public void RickyAndLucy_PlacedSecond()
        {
            var finalPlacement = _SUT.FinalPlacements.Single(x => x.Contestant == rickyAndLucy);
            Assert.Equal(finalPlacement.Place, 2);
        }

        [Fact]
        public void FredAndGinger_PlacedThird()
        {
            var finalPlacement = _SUT.FinalPlacements.Single(x => x.Contestant == fredAndGinger);
            Assert.Equal(finalPlacement.Place, 3);
        }

        [Fact]
        public void WardAndJune_PlacedFourth()
        {
            var finalPlacement = _SUT.FinalPlacements.Single(x => x.Contestant == wardAndJune);
            Assert.Equal(finalPlacement.Place, 4);
        }

        [Fact]
        public void GeorgeAndGrace_PlacedFifth()
        {
            var finalPlacement = _SUT.FinalPlacements.Single(x => x.Contestant == georgeAndGracie);
            Assert.Equal(finalPlacement.Place, 5);
        }

        [Fact]
        public void RhettAndScarlett_PlacedSixth()
        {
            var finalPlacement = _SUT.FinalPlacements.Single(x => x.Contestant == rhettAndScarlett);
            Assert.Equal(finalPlacement.Place, 6);
        }

        [Fact]
        public void KenAndBarbie_PlacedSeventh()
        {
            var finalPlacement = _SUT.FinalPlacements.Single(x => x.Contestant == kenAndBarbie);
            Assert.Equal(finalPlacement.Place, 7);
        }

        [Fact]
        public void MarcAndCleo_PlacedEigth()
        {
            var finalPlacement = _SUT.FinalPlacements.Single(x => x.Contestant == marcAndCleo);
            Assert.Equal(finalPlacement.Place, 8);
        }

        [Fact]
        public void BarneyAndBetty_PlacedNinth()
        {
            var finalPlacement = _SUT.FinalPlacements.Single(x => x.Contestant == barneyAndBetty);
            Assert.Equal(finalPlacement.Place, 9);
        }

        [Fact]
        public void RockyAndAdrian_PlacedTenth()
        {
            var finalPlacement = _SUT.FinalPlacements.Single(x => x.Contestant == rockyAndAdrian);
            Assert.Equal(finalPlacement.Place, 10);
        }

        [Fact]
        public void RomieAndJulie_PlacedEleventh()
        {
            var finalPlacement = _SUT.FinalPlacements.Single(x => x.Contestant == romieAndJulie);
            Assert.Equal(finalPlacement.Place, 11);
        }

        [Fact]
        public void IkeAndMamie_PlacedTwelfth()
        {
            var finalPlacement = _SUT.FinalPlacements.Single(x => x.Contestant == ikeAndMamie);
            Assert.Equal(finalPlacement.Place, 12);
        }
    }
}
