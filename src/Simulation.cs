using System.IO;

namespace SelfishMeme
{
    public class Simulation : ISimulation
    {
        private readonly IPopulation initialPopulation;
        private readonly TextWriter outputStream;
        private readonly IBreedingSeasonFactory breedingSeasonFactory;

        public Simulation(Population initialPopulation
                            , IBreedingSeasonFactory breedingSeasonFactory
                            , TextWriter outputStream)
        {
            this.initialPopulation = initialPopulation;
            this.breedingSeasonFactory = breedingSeasonFactory;
            this.outputStream = outputStream;
        }

        public void Run()
        {
            var breedingSeason = breedingSeasonFactory.Build(initialPopulation);
            breedingSeason.ResolveConfrontations();
            var population = breedingSeason.GetNewPopulation();
            population.WriteOutput(outputStream);
        }

    }
}