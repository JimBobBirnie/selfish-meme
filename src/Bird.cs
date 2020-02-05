using System.Collections.Generic;

namespace SelfishMeme
{
    public class Bird
    {
     
        private BirdType birdType;

        public Bird(BirdType birdType)
        {
            this.birdType = birdType;
        }

        public int LifePoints { get; set; }
    }
}