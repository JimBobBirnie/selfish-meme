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
    }
}