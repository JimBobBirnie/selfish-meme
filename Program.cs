using System;

namespace SelfishMeme
{
    class Program
    {
        private const int WinPayOff = 50;
        private const int timeWastingPenalty = 10;
        private const int losingPenalty = 100;
        private const int startHawks = 100;
        private const int startDoves = 15;
        static void Main(string[] args)
        {


            Population population = new Population(startDoves, startHawks);

            ConfrontationResolver confrontationResolver = new ConfrontationResolver(WinPayOff, timeWastingPenalty, losingPenalty);
            const int confrontations = 1000;
            ConsoleLogger logger = new ConsoleLogger();
            BreedingSeason breedingSeason = new BreedingSeason(population, confrontations, confrontationResolver, logger);
            breedingSeason.ResolveConfrontations();
            population.PrintState();
        }
    }
}
