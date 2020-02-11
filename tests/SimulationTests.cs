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
            Mock<IPopulationOutputStream> outputStreamMock = new Mock<IPopulationOutputStream>();
            var simulation = new Simulation(initialPopulation
                                        , confrontationsPerSeason
                                        , breedingSeasonFactoryMock.Object
                                        , confrontationResolverMock.Object
                                        , consoleMock.Object
                                        , outputStreamMock.Object);
            Mock<IBreedingSeason> breedingSeasonMock = new Mock<IBreedingSeason>();
            breedingSeasonFactoryMock.Setup(s => s.Build(initialPopulation
                            , confrontationsPerSeason
                            , confrontationResolverMock.Object
                            , consoleMock.Object))
                            .Returns(breedingSeasonMock.Object);
            Mock<IPopulation> populationMock = new Mock<IPopulation>();
            breedingSeasonMock.Setup(bs => bs.GetNewPopulation()).Returns(populationMock.Object);
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
            Mock<IPopulationOutputStream> outputStreamMock = new Mock<IPopulationOutputStream>();
            var simulation = new Simulation(initialPopulation
                                        , confrontationsPerSeason
                                        , breedingSeasonFactoryMock.Object
                                        , confrontationResolverMock.Object
                                        , consoleMock.Object
                                        , outputStreamMock.Object);
            var breedingSeasonMock = new Mock<IBreedingSeason>();
            var breedingSeason = breedingSeasonMock.Object;
            breedingSeasonFactoryMock.Setup(s => s.Build(initialPopulation
                            , confrontationsPerSeason
                            , confrontationResolverMock.Object
                            , consoleMock.Object))
                            .Returns(breedingSeason);
            breedingSeasonMock.Setup(bs => bs.ResolveConfrontations());
            Mock<IPopulation> populationMock = new Mock<IPopulation>();
            breedingSeasonMock.Setup(bs => bs.GetNewPopulation()).Returns(populationMock.Object);
            simulation.Run();
            breedingSeasonMock.VerifyAll();
        }

        [Fact]
        public void ResolveSimulationCreatesNextGeneration()
        {
            var initialPopulation = new Population(0, 0);
            var confrontationResolverMock = new Mock<IConfrontationResolver>();
            var consoleMock = new Mock<IConsole>();
            var confrontationsPerSeason = 456723;
            var breedingSeasonFactoryMock = new Mock<IBreedingSeasonFactory>();
            Mock<IPopulationOutputStream> outputStreamMock = new Mock<IPopulationOutputStream>();
            var simulation = new Simulation(initialPopulation
                                        , confrontationsPerSeason
                                        , breedingSeasonFactoryMock.Object
                                        , confrontationResolverMock.Object
                                        , consoleMock.Object
                                        , outputStreamMock.Object);
            var breedingSeasonMock = new Mock<IBreedingSeason>();
            var breedingSeason = breedingSeasonMock.Object;
            breedingSeasonFactoryMock.Setup(s => s.Build(initialPopulation
                            , confrontationsPerSeason
                            , confrontationResolverMock.Object
                            , consoleMock.Object))
                            .Returns(breedingSeason);
            Mock<IPopulation> populationMock = new Mock<IPopulation>();
            breedingSeasonMock.Setup(bs => bs.GetNewPopulation()).Returns(populationMock.Object);
            simulation.Run();
            breedingSeasonMock.VerifyAll();
        }

        [Fact]
        public void SimulationWritesNextGenerationToOutputStream()
        {
            var initialPopulation = new Population(0, 0);
            var confrontationResolverMock = new Mock<IConfrontationResolver>();
            var consoleMock = new Mock<IConsole>();
            var confrontationsPerSeason = 456723;
            var breedingSeasonFactoryMock = new Mock<IBreedingSeasonFactory>();
            Mock<IPopulationOutputStream> outputStreamMock = new Mock<IPopulationOutputStream>();
            var simulation = new Simulation(initialPopulation
                                        , confrontationsPerSeason
                                        , breedingSeasonFactoryMock.Object
                                        , confrontationResolverMock.Object
                                        , consoleMock.Object
                                        , outputStreamMock.Object);
            var breedingSeasonMock = new Mock<IBreedingSeason>();
            var breedingSeason = breedingSeasonMock.Object;
            breedingSeasonFactoryMock.Setup(s => s.Build(initialPopulation
                            , confrontationsPerSeason
                            , confrontationResolverMock.Object
                            , consoleMock.Object))
                            .Returns(breedingSeason);
            Mock<IPopulation> populationMock = new Mock<IPopulation>();
            breedingSeasonMock.Setup(bs => bs.GetNewPopulation()).Returns(populationMock.Object);
            populationMock.Setup(p => p.WriteOutput(outputStreamMock.Object));
            simulation.Run();
            populationMock.VerifyAll();
        }
    }
}