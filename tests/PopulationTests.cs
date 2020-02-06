using Xunit;

namespace SelfishMeme {
    public class PopulationTests {
        [Fact]
        public void PopulationHasCorrectNumberOfBirds () {
            var population = new Population (70, 30);
            Assert.Equal (100, population.getSize ());
        }

        [Fact]
        public void PopulationHasCorrectNumberOfDovesAndHawks () {
            var population = new Population (70, 30);
            Assert.Equal (70, population.getDoves ());
            Assert.Equal (30, population.getHawks ());

        }

        [Fact]
        public void GetBirdAtReturnsCorrectBird () {
            var population = new Population (70, 30);
            Assert.Same (population.getBirdAt (14), population.getBirdAt (14));
            Assert.NotSame (population.getBirdAt (23), population.getBirdAt (47));
        }
    }
}