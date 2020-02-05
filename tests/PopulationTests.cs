using Xunit;

namespace SelfishMeme
{
    public class PopulationTests
    {
        [Fact]
        public void PopulationHasCorrectNumberOfBirds(){
            var population = new Population(70,30);
            Assert.Equal(100, population.getSize());
        }

        [Fact]public void PopulationHasCorrectNumberOfDovesAndHawks(){
                        var population = new Population(70, 30);
            Assert.Equal(70, population.getDoves());
            Assert.Equal(30, population.getHawks());

        }
    }
}