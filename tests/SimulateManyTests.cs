using Xunit;
using Moq;
using System.IO;

namespace SelfishMeme
{
    public class SimulateManyTests
    {
        [Fact]
        public void RunsTheSimulationManyTimes()
        {
            var simulationMock = new Mock<ISimulation>();
            var simulationMany = new SimulateMany(10, simulationMock.Object);
            simulationMany.Run();
            simulationMock.Verify(s => s.Run(), Times.Exactly(10));
        }
    }
}