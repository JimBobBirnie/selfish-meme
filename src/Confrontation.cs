using System;

namespace SelfishMeme
{
    public class Confrontation
    {

        private int WinPayOff { get; set; }
        private int TimeWastingPenalty { get; set; }
        private int LosingPenalty { get; set; }

        public Confrontation(int winPayOff, int timeWastingPenalty, int losingPenalty)
        {
            WinPayOff = winPayOff;
            TimeWastingPenalty = timeWastingPenalty;
            LosingPenalty = losingPenalty;
        }

        public void Resolve(Bird firstBird, Bird secondBird)
        {
            if (firstBird.BirdType == BirdType.Hawk &&
            secondBird.BirdType == BirdType.Dove)
            {
                firstBird.LifePoints += WinPayOff;
            }
            else if (firstBird.BirdType == BirdType.Dove &&
            secondBird.BirdType == BirdType.Hawk)
            {
                secondBird.LifePoints += WinPayOff;
            }
            else if (firstBird.BirdType == BirdType.Dove &&
            secondBird.BirdType == BirdType.Dove)
            {
                firstBird.LifePoints -= TimeWastingPenalty;
                secondBird.LifePoints -= TimeWastingPenalty;
                var random = new Random();
                if (random.Next(2) == 0)
                {
                    firstBird.LifePoints += WinPayOff;
                }
                else
                {
                    secondBird.LifePoints += WinPayOff;
                }
            }
            else if (firstBird.BirdType == BirdType.Hawk
            && secondBird.BirdType == BirdType.Hawk)
            {
                var random = new Random();
                if (random.Next(2) == 0)
                {
                    firstBird.LifePoints += WinPayOff;
                    secondBird.LifePoints -= LosingPenalty;
                }
                else
                {
                    secondBird.LifePoints += WinPayOff;
                    firstBird.LifePoints -= LosingPenalty;
                }
            }
        }
    }
}