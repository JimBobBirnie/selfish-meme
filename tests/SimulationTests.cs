using Xunit;
using Moq;

namespace SelfishMeme
{
    public class SimulationTests
    {
        [Fact]
        public void RunSimulationCreatesABreedingSeasonFromInitialPopulation()
        {
            var initialPopulation = new Population(0, 0);
            var confrontationResolverMock = new Mock<IConfrontationResolver>();
            var consoleMock = new Mock<IConsole>();
            var confrontationsPerSeason = 456723;
            var breedingSeasonFactoryMock = new Mock<IBreedingSeasonFactory>();
            var simulation = new Simulation(initialPopulation
                                        , confrontationsPerSeason
                                        , breedingSeasonFactoryMock.Object
                                        , confrontationResolverMock.Object
                                        , consoleMock.Object);
            breedingSeasonFactoryMock.Setup(s => s.Build(initialPopulation
                            , confrontationsPerSeason
                            , confrontationResolverMock.Object
                            , consoleMock.Object))
                            .Returns(new Mock<IBreedingSeason>().Object);
            simulation.Run();
            breedingSeasonFactoryMock.VerifyAll();
        }
        [Fact]
        public void ResolveSimulationResolvesConfrontations()
        {
            var initialPopulation = new Population(0, 0);
            var confrontationResolverMock = new Mock<IConfrontationResolver>();
            var consoleMock = new Mock<IConsole>();
            var confrontationsPerSeason = 456723;
            var breedingSeasonFactoryMock = new Mock<IBreedingSeasonFactory>();
            var simulation = new Simulation(initialPopulation
                                        , confrontationsPerSeason
                                        , breedingSeasonFactoryMock.Object
                                        , confrontationResolverMock.Object
                                        , consoleMock.Object);
            var breedingSeasonMock = new Mock<IBreedingSeason>();
            var breedingSeason = breedingSeasonMock.Object;
            breedingSeasonFactoryMock.Setup(s => s.Build(initialPopulation
                            , confrontationsPerSeason
                            , confrontationResolverMock.Object
                            , consoleMock.Object))
                            .Returns(breedingSeason);
            breedingSeasonMock.Setup(bs=>bs.ResolveConfrontations());
            simulation.Run();
            breedingSeasonMock.VerifyAll();
        }

        [Fact]
        public void ResolveSimulationCreatesNextGeneration()
        {

        }
    }
}