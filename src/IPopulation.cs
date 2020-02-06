namespace SelfishMeme
{
    public interface IPopulation
    {
        Bird getBirdAt(int index);
        int getBreedingDoves();
        int getBreedingHawks();
        int getDoves();
        int getHawks();
        int getSize();
        void PrintState();
    }
}