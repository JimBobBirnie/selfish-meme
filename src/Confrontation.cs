using System;

namespace SelfishMeme{
    public class Confrontation
    {
        public void Resolve(Bird firstBird, Bird secondBird)
        {
            if (firstBird.BirdType == BirdType.Hawk && secondBird.BirdType == BirdType.Dove){
                firstBird.LifePoints += 50;
            }
        }
    }
}