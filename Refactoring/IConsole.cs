using System;

namespace Refactoring
{
    public interface IConsole
    {
        void WriteLine(string text);
        ConsoleKeyInfo ReadKey();
        string ReadLine();
    }
}