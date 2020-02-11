namespace SelfishMeme
{
    public class BreedingSeasonFactory : IBreedingSeasonFactory
    {
        public IPopulation Population { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int Confrontations { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IConfrontationResolver ConfrontationResolver { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IConsole Console { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public BreedingSeason Build()
        {
            throw new System.NotImplementedException();
        }

        public IBreedingSeason Build(IPopulation population
                                    , int confrontations
                                    , IConfrontationResolver confrontationResolver
                                    , IConsole console)
        {
            return new BreedingSeason(population, confrontations, confrontationResolver, console);
        }
    }
}