namespace SelfishMeme
{
    public class BreedingSeasonFactory : IBreedingSeasonFactory
    {
        private readonly int confrontationsPerSeason;
        private readonly ConfrontationResolver confrontationResolver;
        private readonly IConsole logger;

        public BreedingSeasonFactory(int confrontationsPerSeason, ConfrontationResolver confrontationResolver, IConsole logger)
        {
            this.confrontationsPerSeason = confrontationsPerSeason;
            this.confrontationResolver = confrontationResolver;
            this.logger = logger;
        }

        public IBreedingSeason Build(IPopulation population)
        {
            return new BreedingSeason(population, confrontationsPerSeason, confrontationResolver, logger);
        }
    }
}