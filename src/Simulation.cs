namespace SelfishMeme
{
    public class Simulation
    {
        private readonly IPopulation initialPopulation;
        private readonly int confrontationsPerSeason;
        private readonly IConfrontationResolver confrontationResolver;
        private readonly IConsole console;
        private readonly IPopulationOutputStream outputStream;
        private IBreedingSeasonFactory breedingSeasonFactory;

        public Simulation(Population initialPopulation
                            , int confrontationsPerSeason
                            , IBreedingSeasonFactory breedingSeasonFactory
                            , IConfrontationResolver confrontationResolver
                            , IConsole console
                            , IPopulationOutputStream outputStream)
        {
            this.initialPopulation = initialPopulation;
            this.confrontationsPerSeason = confrontationsPerSeason;
            this.breedingSeasonFactory = breedingSeasonFactory;
            this.confrontationResolver = confrontationResolver;
            this.console = console;
            this.outputStream = outputStream;
        }

        public void Run()
        {
            var breedingSeason = breedingSeasonFactory.Build(initialPopulation
                    , confrontationsPerSeason
                    , confrontationResolver
                    , console);
            breedingSeason.ResolveConfrontations();
            var population = breedingSeason.GetNewPopulation();
            population.WriteOutput(outputStream);
        }

    }
}