using System;

namespace SelfishMeme
{
    public class BreedingSeason
    {
        private readonly Population population;
        private readonly int confrontations;
        private readonly IConfrontationResolver confrontationResolver;

        public BreedingSeason(Population population, int confrontations, IConfrontationResolver confrontationResolver)
        {
            this.population = population;
            this.confrontations = confrontations;
            this.confrontationResolver = confrontationResolver;
        }

        public void ResolveConfrontations()
        {
            var r = new Random();
            for (int i = 0; i < confrontations; i++)
            {
                var index1 = r.Next(population.getSize());
                var index2 = -1;
                do
                {
                    index2 = r.Next(population.getSize());
                } while (index1 == index2);
                confrontationResolver.Resolve(population.getBirdAt(index1), population.getBirdAt(index2));
            }
        }
    }
}