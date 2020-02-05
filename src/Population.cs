using System;
using System.Collections.Generic;
using System.Linq;

namespace SelfishMeme
{
    public class Population
    {
        private List<Bird> birds;


        public Population(int doves, int hawks)
        {
            birds = new List<Bird>();
            for (int i = 0; i < doves; i++)
            {
                birds.Add(new Bird(BirdType.Dove));
            }
            for (int i = 0; i < hawks; i++)
            {
                birds.Add(new Bird(BirdType.Hawk));
            }
        }

        public int getDoves()
        {
            return birds.Count(b => b.BirdType == BirdType.Dove);
        }

        public int getHawks()
        {
            return birds.Count(b => b.BirdType == BirdType.Hawk);
        }

        public int getSize()
        {
            return birds.Count;
        }

    }
}