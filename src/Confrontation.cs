using System;

namespace SelfishMeme
{
    public class Confrontation
    {
        private const int winPayOff = 50;
        private const int timeWastingPenalty = 10;
        private const int losingPenalty = 100;

        public void Resolve(Bird firstBird, Bird secondBird)
        {
            if (firstBird.BirdType == BirdType.Hawk &&
            secondBird.BirdType == BirdType.Dove)
            {
                firstBird.LifePoints += winPayOff;
            }
            else if (firstBird.BirdType == BirdType.Dove &&
            secondBird.BirdType == BirdType.Hawk)
            {
                secondBird.LifePoints += winPayOff;
            }
            else if (firstBird.BirdType == BirdType.Dove &&
            secondBird.BirdType == BirdType.Dove)
            {
                firstBird.LifePoints -= timeWastingPenalty;
                secondBird.LifePoints -= timeWastingPenalty;
                var random = new Random();
                if (random.Next(2) == 0)
                {
                    firstBird.LifePoints += winPayOff;
                }
                else
                {
                    secondBird.LifePoints += winPayOff;
                }
            }
            else if (firstBird.BirdType == BirdType.Hawk
            && secondBird.BirdType == BirdType.Hawk)
            {
                var random = new Random();
                if (random.Next(2) == 0)
                {
                    firstBird.LifePoints += winPayOff;
                    secondBird.LifePoints -= losingPenalty;
                }
                else
                {
                    secondBird.LifePoints += winPayOff;
                    firstBird.LifePoints -= losingPenalty;
                }
            }
        }
    }
}