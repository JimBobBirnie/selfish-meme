namespace SelfishMeme
{
    public class Simulation
    {
        private readonly IPopulation initialPopulation;
        private readonly int confrontationsPerSeason;
        private readonly IConfrontationResolver confrontationResolver;
        private readonly IConsole console;
        private IBreedingSeasonFactory breedingSeasonFactory;



        public Simulation(Population initialPopulation
                            , int confrontationsPerSeason
                            , IBreedingSeasonFactory breedingSeasonFactory
                            , IConfrontationResolver confrontationResolver
                            , IConsole console)
        {
            this.initialPopulation = initialPopulation;
            this.confrontationsPerSeason = confrontationsPerSeason;
            this.breedingSeasonFactory = breedingSeasonFactory;
            this.confrontationResolver = confrontationResolver;
            this.console = console;

        }

        public void Run()
        {
            breedingSeasonFactory.Build(initialPopulation
                    , confrontationsPerSeason
                    , confrontationResolver
                    , console);
        }

    }
}