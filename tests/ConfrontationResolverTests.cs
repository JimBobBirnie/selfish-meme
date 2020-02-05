using System;
using Xunit;
namespace SelfishMeme
{
    public class ConfrontationResolverTests
    {
        private const int LosingPenalty = 100;
        private const int TimeWastingPenalty = 10;
        private const int WinPayOff = 50;

        [Fact]
        public void HawkAlwaysBeatsDoveByWalkover()
        {
            var hawk = new Bird(BirdType.Hawk);
            var dove = new Bird(BirdType.Dove);
            var confrontation = new ConfrontationResolver(WinPayOff, TimeWastingPenalty, LosingPenalty);
            confrontation.Resolve(hawk, dove);
            Assert.Equal(WinPayOff, hawk.LifePoints);
            Assert.Equal(0, dove.LifePoints);
        }

        [Fact]
        public void DoveAlwaysLosesToHawkByWalkover()
        {
            var hawk = new Bird(BirdType.Hawk);
            var dove = new Bird(BirdType.Dove);
            var confrontation = new ConfrontationResolver(WinPayOff, TimeWastingPenalty, LosingPenalty);
            confrontation.Resolve(dove, hawk);
            Assert.Equal(WinPayOff, hawk.LifePoints);
            Assert.Equal(0, dove.LifePoints);
        }

        [Fact]
        public void DoveAgainstDoveWastesTimeButOneWins()
        {
            var dove1 = new Bird(BirdType.Dove);
            var dove2 = new Bird(BirdType.Dove);
            var confrontation = new ConfrontationResolver(WinPayOff, TimeWastingPenalty, LosingPenalty);
            confrontation.Resolve(dove1, dove2);

            Assert.Equal(WinPayOff - 2 * TimeWastingPenalty, dove1.LifePoints + dove2.LifePoints);
        }
        [Fact]
        public void HawkAgainstHawkHasAWinnerAndALoser()
        {
            var hawk1 = new Bird(BirdType.Hawk);
            var hawk2 = new Bird(BirdType.Hawk);
            var confrontation = new ConfrontationResolver(WinPayOff, TimeWastingPenalty, LosingPenalty);
            confrontation.Resolve(hawk1, hawk2);

            Assert.Equal(WinPayOff - LosingPenalty, hawk1.LifePoints + hawk2.LifePoints);
        }

    }
}