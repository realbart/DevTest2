using System;

namespace Refactoring
{
    public class ConsoleWrapper : IConsole
    {
        public ConsoleKeyInfo ReadKey() => Console.ReadKey();
        public string ReadLine() => Console.ReadLine();
        public void WriteLine(string text) => Console.WriteLine(text);
    }
}