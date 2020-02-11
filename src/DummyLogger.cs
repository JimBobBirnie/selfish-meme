using System;

namespace SelfishMeme
{
    public class DummyLogger : IConsole
    {
        public void WriteLine()
        {
        }

        public void WriteLine(object o)
        {
        }
    }
}