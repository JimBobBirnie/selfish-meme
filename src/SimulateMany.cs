using System;

namespace SelfishMeme
{
    public class SimulateMany
    {
        private readonly int times;
        private readonly ISimulation simulation;

        public SimulateMany(int times, ISimulation simulation)
        {
            this.times = times;
            this.simulation = simulation;
        }

        public void Run()
        {
            for (var index = 0; index < this.times; ++index)
            {
                simulation.Run();
            }
        }
    }
}