using System;

namespace SelfishMeme
{
    public class ConsoleLogger : IConsole
    {
        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void WriteLine(object o)
        {
            Console.WriteLine(o);
        }
    }
}