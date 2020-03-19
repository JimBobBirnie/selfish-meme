using System;

namespace SelfishMeme
{
    public class BreedingSeason : IBreedingSeason
    {
        private readonly IPopulation population;
        private readonly int confrontations;
        private readonly IConfrontationResolver confrontationResolver;
        private readonly IConsole console;

        private const bool writeConfrontations = false;

        public BreedingSeason(IPopulation population
                            , int confrontations
                            , IConfrontationResolver confrontationResolver
                            , IConsole console)
        {
            this.population = population;
            this.confrontations = confrontations;
            this.confrontationResolver = confrontationResolver;
            this.console = console;
        }

        public void ResolveConfrontations()
        {
            console.WriteLine();
            console.WriteLine("Breeding season starting.........");
            console.WriteLine();
            var r = new Random();
            for (int i = 0; i < confrontations; i++)
            {
                var index1 = r.Next(population.getSize());
                var index2 = -1;
                do
                {
                    index2 = r.Next(population.getSize());
                } while (index1 == index2);

                Bird firstBird = population.getBirdAt(index1);
                Bird secondBird = population.getBirdAt(index2);
                WriteBeforeConfrontation(firstBird, secondBird);
                confrontationResolver.Resolve(firstBird, secondBird);
                WriteAfterConfrontation(firstBird, secondBird);
            }
            console.WriteLine("Breeding season ending.........");
            console.WriteLine("Hawks: {0}    Doves: {1}", population.getHawks(), population.getDoves());
            console.WriteLine();
        }

        private void WriteAfterConfrontation(Bird firstBird, Bird secondBird)
        {
            if (writeConfrontations)
            {
                console.WriteLine("After confrontation:");
                console.WriteLine(firstBird);
                console.WriteLine(secondBird);
            }
        }

        private void WriteBeforeConfrontation(Bird firstBird, Bird secondBird)
        {
            if (writeConfrontations)
            {
                console.WriteLine("Before confrontation:");
                console.WriteLine(firstBird);
                console.WriteLine(secondBird);
            }
        }

        public IPopulation GetNewPopulation()
        {
            return new Population(population.getBreedingDoves() * 2, population.getBreedingHawks() * 2);
        }
    }
}