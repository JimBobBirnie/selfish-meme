using Xunit;
using Moq;
using System.IO;

namespace SelfishMeme
{
    public class SimulationTests
    {
        [Fact]
        public void RunSimulationCreatesABreedingSeasonFromInitialPopulation()
        {
            var initialPopulation = new Population(0, 0);
            var breedingSeasonFactoryMock = new Mock<IBreedingSeasonFactory>();
            Mock<TextWriter> outputStreamMock = new Mock<TextWriter>();
            var simulation = new Simulation(initialPopulation
                                        , breedingSeasonFactoryMock.Object
                                        , outputStreamMock.Object);
            Mock<IBreedingSeason> breedingSeasonMock = new Mock<IBreedingSeason>();
            breedingSeasonFactoryMock.Setup(s => s.Build(initialPopulation))
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
            var breedingSeasonFactoryMock = new Mock<IBreedingSeasonFactory>();
            Mock<TextWriter> outputStreamMock = new Mock<TextWriter>();
            var simulation = new Simulation(initialPopulation
                                        , breedingSeasonFactoryMock.Object
                                        , outputStreamMock.Object);
            var breedingSeasonMock = new Mock<IBreedingSeason>();
            var breedingSeason = breedingSeasonMock.Object;
            breedingSeasonFactoryMock.Setup(s => s.Build(initialPopulation))
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
            var breedingSeasonFactoryMock = new Mock<IBreedingSeasonFactory>();
            Mock<TextWriter> outputStreamMock = new Mock<TextWriter>();
            var simulation = new Simulation(initialPopulation
                                        , breedingSeasonFactoryMock.Object
                                        , outputStreamMock.Object);
            var breedingSeasonMock = new Mock<IBreedingSeason>();
            var breedingSeason = breedingSeasonMock.Object;
            breedingSeasonFactoryMock.Setup(s => s.Build(initialPopulation))
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
            var breedingSeasonFactoryMock = new Mock<IBreedingSeasonFactory>();
            Mock<TextWriter> outputStreamMock = new Mock<TextWriter>();
            var simulation = new Simulation(initialPopulation
                                        , breedingSeasonFactoryMock.Object
                                        , outputStreamMock.Object);
            var breedingSeasonMock = new Mock<IBreedingSeason>();
            var breedingSeason = breedingSeasonMock.Object;
            breedingSeasonFactoryMock.Setup(s => s.Build(initialPopulation))
                            .Returns(breedingSeason);
            Mock<IPopulation> populationMock = new Mock<IPopulation>();
            breedingSeasonMock.Setup(bs => bs.GetNewPopulation()).Returns(populationMock.Object);
            populationMock.Setup(p => p.WriteOutput(outputStreamMock.Object));
            simulation.Run();
            populationMock.VerifyAll();
        }
    }
}