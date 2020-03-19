using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace SelfishMeme
{

    public class Population : IPopulation
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

        public Bird getBirdAt(int index)
        {
            return birds[index];
        }

        // public void PrintState()
        // {

        //     Console.WriteLine("Total Birds in population: {0}", birds.Count);
        //     foreach (Bird bird in this.birds.OrderByDescending(b => b.LifePoints))
        //     {
        //         Console.WriteLine(bird.ToString());
        //     }
        //     Console.WriteLine("Breeding hawks: {0}", getBreedingHawks());
        //     Console.WriteLine("Breeding doves: {0}", getBreedingDoves());
        // }

        public int getBreedingDoves()
        {
            int topHalfCount = birds.Count / 2;
            return birds.OrderByDescending(b => b.LifePoints)
                .Take(topHalfCount)
                .Count(b => b.BirdType == BirdType.Dove);
        }

        public int getBreedingHawks()
        {
            int topHalfCount = birds.Count / 2;
            return birds.OrderByDescending(b => b.LifePoints)
                .Take(topHalfCount)
                .Count(b => b.BirdType == BirdType.Hawk);
        }

        public void WriteOutput(TextWriter outputStream)
        {
            var jsonOutput = JsonConvert.SerializeObject(new
            {
                doves = this.getDoves(),
                hawks = this.getHawks()
            });

            outputStream.WriteLine(jsonOutput);
            outputStream.Flush();
        }
    }
}