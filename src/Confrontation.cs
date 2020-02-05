using System;

namespace SelfishMeme
{
    public class Confrontation
    {
        public void Resolve(Bird firstBird, Bird secondBird)
        {
            if (firstBird.BirdType == BirdType.Hawk &&
            secondBird.BirdType == BirdType.Dove)
            {
                firstBird.LifePoints += 50;
            }
            else if (firstBird.BirdType == BirdType.Dove &&
            secondBird.BirdType == BirdType.Hawk)
            {
                secondBird.LifePoints += 50;
            }
        }
    }
}