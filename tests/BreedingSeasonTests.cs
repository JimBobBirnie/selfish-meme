using Xunit;
using Moq;
using System.Collections.Generic;

namespace SelfishMeme
{
    public class BreedingSeasonTests
    {
        private Mock<IConfrontationResolver> mock;

        [Fact]
        public void ConfrontationsTakePlaceInBreedingSeason()
        {
            mock = new Mock<IConfrontationResolver>();
            var population = new Population(50, 50);
            var breedingSeason = new BreedingSeason(population, 1000, mock.Object, new Mock<IConsole>().Object);
            for (int i = 0; i < 1000; i++)
            {
                mock.Setup(cr => cr.Resolve(It.IsAny<Bird>(), It.IsAny<Bird>()));
            }
            breedingSeason.ResolveConfrontations();
            mock.VerifyAll();
        }

        [Theory]
        [InlineData(5, 10)]
        [InlineData(50, 28)]
        public void NewPopulationIsFormedFromTopHalfOfExistingPopulation(int breedingDoves, int breedingHawks)
        {
            var mock = new Mock<IPopulation>();
            mock.Setup(p => p.getBreedingDoves()).Returns(breedingDoves);
            mock.Setup(p => p.getBreedingHawks()).Returns(breedingHawks);
            BreedingSeason breedingSeason = new BreedingSeason(mock.Object, 0, null, new Mock<IConsole>().Object);
            Population newPopulation = breedingSeason.GetNewPopulation();
            Assert.Equal(breedingDoves * 2, newPopulation.getDoves());
            Assert.Equal(breedingHawks * 2, newPopulation.getHawks());
        }
    }

}