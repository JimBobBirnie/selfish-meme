using System.IO;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace SelfishMeme
{
    public class PopulationTests
    {
        private readonly ITestOutputHelper output;

        public PopulationTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void PopulationHasCorrectNumberOfBirds()
        {
            var population = new Population(70, 30);
            Assert.Equal(100, population.getSize());
        }

        [Fact]
        public void PopulationHasCorrectNumberOfDovesAndHawks()
        {
            var population = new Population(70, 30);
            Assert.Equal(70, population.getDoves());
            Assert.Equal(30, population.getHawks());

        }

        [Fact]
        public void GetBirdAtReturnsCorrectBird()
        {
            var population = new Population(70, 30);
            Assert.Same(population.getBirdAt(14), population.getBirdAt(14));
            Assert.NotSame(population.getBirdAt(23), population.getBirdAt(47));
        }

        [Fact]
        public void WriteOutputShouldWriteCountOfDovesAndHawksToStream()
        {
            var writerMock = new Mock<TextWriter>();
            writerMock.Setup(w => w.WriteLine("{\"doves\":70,\"hawkes\":30}"));

            var population = new Population(70, 30);
            population.WriteOutput(writerMock.Object);
            writerMock.VerifyAll();
        }

        [Fact]
        public void WriteOutputShouldFlushStreamEachTime()
        {
            var writerMock = new Mock<TextWriter>();
            var population = new Population(70, 30);
            population.WriteOutput(writerMock.Object);
            writerMock.Verify(w => w.Flush());
        }
    }
}