using System.Collections.Generic;

namespace SelfishMeme
{
    public class Bird
    {

        public BirdType BirdType { get; private set; }

        public Bird(BirdType birdType)
        {
            this.BirdType = birdType;
        }



        public int LifePoints { get; set; }

        public override string ToString()
        {
            return string.Format("Type: {0} - LifePoints: {1}", BirdType, LifePoints);
        }
    }
}