namespace SelfishMeme
{
    public interface IBreedingSeasonFactory
    {
        IBreedingSeason Build(IPopulation population);
    }
}