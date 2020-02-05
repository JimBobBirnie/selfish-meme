using Xunit;
namespace SelfishMeme
{
    public class ConfrontationTests
    {
        [Theory]
        [InlineData(BirdType.Hawk, BirdType.Dove)]
        public void HawkAlwaysBeatsDoveByWalkover(BirdType firstBirdType, BirdType secondBirdType)
        {
            var hawk = new Bird(firstBirdType);
            var dove = new Bird(secondBirdType);
            var confrontation = new Confrontation();
            confrontation.Resolve(hawk, dove);
            Assert.Equal(50, hawk.LifePoints);
            Assert.Equal(0, dove.LifePoints);
        }
    }
}