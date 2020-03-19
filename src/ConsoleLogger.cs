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

        public void WriteLine(string format, object arg0, object arg1){
            Console.WriteLine(format, arg0, arg1);
        }
    }
}