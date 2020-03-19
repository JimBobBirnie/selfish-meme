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

        public void WriteLine(string format, object arg0, object arg1)
        {
        }
    }
}