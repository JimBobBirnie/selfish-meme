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
        const int confrontationsPerSeason = 1000;
        static void Main(string[] args)
        {
            ConsoleLogger logger = new ConsoleLogger();
            ConfrontationResolver confrontationResolver = new ConfrontationResolver(WinPayOff, timeWastingPenalty, losingPenalty);
            Population initialPopulation = new Population(startDoves, startHawks);
            var simulation = new Simulation(initialPopulation, confrontationsPerSeason, new BreedingSeasonFactory(), confrontationResolver, logger);
            simulation.Run();
        }
    }
}
