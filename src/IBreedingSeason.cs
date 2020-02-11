namespace SelfishMeme
{
    public interface IBreedingSeason
    {
        void ResolveConfrontations();
        IPopulation GetNewPopulation();
      }
}