using System;
using Xunit;
namespace SelfishMeme
{
    public class ConfrontationTests
    {
        [Fact]
        public void HawkAlwaysBeatsDoveByWalkover()
        {
            var hawk = new Bird(BirdType.Hawk);
            var dove = new Bird(BirdType.Dove);
            var confrontation = new Confrontation();
            confrontation.Resolve(hawk, dove);
            Assert.Equal(50, hawk.LifePoints);
            Assert.Equal(0, dove.LifePoints);
        }

        [Fact]
        public void DoveAlwaysLosesToHawkByWalkover()
        {
            var hawk = new Bird(BirdType.Hawk);
            var dove = new Bird(BirdType.Dove);
            var confrontation = new Confrontation();
            confrontation.Resolve(dove, hawk);
            Assert.Equal(50, hawk.LifePoints);
            Assert.Equal(0, dove.LifePoints);
        }

        [Fact]
        public void DoveAgainstDoveWastesTimeButOneWins()
        {
            var dove1 = new Bird(BirdType.Dove);
            var dove2 = new Bird(BirdType.Dove);
            var confrontation = new Confrontation();
            confrontation.Resolve(dove1, dove2);

            Assert.Equal(30, dove1.LifePoints + dove2.LifePoints);
        }
        [Fact]
        public void HawkAgainstHawkHasAWinnerAndALoser()
        {
            var hawk1 = new Bird(BirdType.Hawk);
            var hawk2 = new Bird(BirdType.Hawk);
            var confrontation = new Confrontation();
            confrontation.Resolve(hawk1, hawk2);
            
            Assert.Equal(-50, hawk1.LifePoints + hawk2.LifePoints);
        }

    }
}