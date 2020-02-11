using System;
using System.IO;

namespace SelfishMeme
{
    class Program
    {
        private const int WinPayOff = 50;
        private const int timeWastingPenalty = 10;
        private const int losingPenalty = 100;
        private const int startHawks = 100;
        private const int startDoves = 15;
        private const int confrontationsPerSeason = 1000;
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Need an output file path for writing population data");
                return;
            }
            string outputFilePath = args[0];
            IConsole logger = new ConsoleLogger();
            ConfrontationResolver confrontationResolver = new ConfrontationResolver(WinPayOff, timeWastingPenalty, losingPenalty);
            Population initialPopulation = new Population(startDoves, startHawks);
            using (TextWriter outputStream = new StreamWriter(File.Open(outputFilePath, FileMode.Create, FileAccess.Write, FileShare.Read)))
            {
                var simulation = new SimulateMany(100, new Simulation(initialPopulation, new BreedingSeasonFactory(confrontationsPerSeason, confrontationResolver, logger), outputStream));
                simulation.Run();
            }
        }
    }
}
