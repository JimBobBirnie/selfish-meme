namespace SelfishMeme
{
    public interface IConsole
    {
        void WriteLine();
        void WriteLine(object o);

        void WriteLine(string format, object arg0, object arg1);
    }
}