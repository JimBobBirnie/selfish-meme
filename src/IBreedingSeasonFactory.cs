namespace SelfishMeme
{
    public interface IBreedingSeasonFactory
    {
        IPopulation Population { get; set; }
        int Confrontations { get; set; }
        IConfrontationResolver ConfrontationResolver { get; set; }
        IConsole Console { get; set; }
        BreedingSeason Build();
        IBreedingSeason Build(IPopulation population
                            , int confrontations
                            , IConfrontationResolver confrontationResolver
                            , IConsole console);
    }
}