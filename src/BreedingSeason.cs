using System;

namespace SelfishMeme
{
    public class BreedingSeason
    {
        private readonly IPopulation population;
        private readonly int confrontations;
        private readonly IConfrontationResolver confrontationResolver;
        private readonly IConsole console;

        public BreedingSeason(IPopulation population, int confrontations, IConfrontationResolver confrontationResolver, IConsole console)
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
                console.WriteLine("Before confrontation:");
                console.WriteLine(firstBird);
                console.WriteLine(secondBird);
                confrontationResolver.Resolve(firstBird, secondBird);
                console.WriteLine("After confrontation:");
                console.WriteLine(firstBird);
                console.WriteLine(secondBird);
            }
            console.WriteLine();
            console.WriteLine("Breeding season ending.........");
            console.WriteLine();
        }

        public Population GetNewPopulation()
        {
            return new Population(population.getBreedingDoves() * 2, population.getBreedingHawks() * 2);
        }
    }
}