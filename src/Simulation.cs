using System.IO;

namespace SelfishMeme
{
    public class Simulation : ISimulation
    {
        private readonly TextWriter outputStream;
        private readonly IBreedingSeasonFactory breedingSeasonFactory;
        private readonly int breedingSeasons;
        private IPopulation currentPopulation;

        public Simulation(Population initialPopulation
                            , IBreedingSeasonFactory breedingSeasonFactory
                            , int breedingSeasons
                            , TextWriter outputStream)
        {
            this.currentPopulation = initialPopulation;
            this.breedingSeasonFactory = breedingSeasonFactory;
            this.breedingSeasons = breedingSeasons;
            this.outputStream = outputStream;
        }

        public void Run()
        {
            for (int i = 0; i < breedingSeasons; i++)
            {
                currentPopulation.WriteOutput(outputStream);
                var nextPopulation = GetNextPopulation(currentPopulation);
                currentPopulation = nextPopulation;
            }
        }

        private IPopulation GetNextPopulation(IPopulation currentPopulation)
        {
            var breedingSeason = breedingSeasonFactory.Build(currentPopulation);
            breedingSeason.ResolveConfrontations();
            return breedingSeason.GetNewPopulation();
        }
    }
}