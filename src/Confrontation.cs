using System;

namespace SelfishMeme
{
    public class Confrontation
    {
        private const int winPayOff = 50;

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
                firstBird.LifePoints -= 10;
                secondBird.LifePoints -= 10;
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
                    secondBird.LifePoints -= 100;
                }
                else
                {
                    secondBird.LifePoints += winPayOff;
                    firstBird.LifePoints -= 100;
                }
            }
        }
    }
}