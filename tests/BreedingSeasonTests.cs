using Xunit;
using Moq;

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
            var breedingSeason = new BreedingSeason(population, 1000, mock.Object);
            for (int i = 0; i < 1000; i++)
            {
                mock.Setup(cr => cr.Resolve(It.IsAny<Bird>(), It.IsAny<Bird>()));
            }
            breedingSeason.ResolveConfrontations();
            mock.VerifyAll();
        }
    }
}