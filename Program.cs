using System;

namespace SelfishMeme
{
    class Program
    {
        private const int WinPayOff = 50;

        static void Main(string[] args)
        {

            const int startDoves = 10;
            const int startHawks = 10;
            Population population = new Population(startDoves, startHawks);
            const int timeWastingPenalty = 10;
            const int losingPenalty = 100;
            ConfrontationResolver confrontationResolver = new ConfrontationResolver(WinPayOff, timeWastingPenalty, losingPenalty);
            const int confrontations = 1000;
            BreedingSeason breedingSeason = new BreedingSeason(population, confrontations, confrontationResolver);
            breedingSeason.ResolveConfrontations();
            population.PrintState();
        }
    }
}
