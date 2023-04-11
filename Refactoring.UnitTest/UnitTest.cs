namespace Refactoring.UnitTest
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Remoting.Messaging;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Refactoring;

    [TestClass]
    public class UnitTest
    {
        private const double TriangleHeight = 13d;
        private const double TriangleWidth = 34d;
        private const double TriangleSurfaceArea = 221d;
        private const double CircleRadius = 23d;
        private const double CircleSurfaceArea = 1661.9d;
        private const double SquareSide = 17d;
        private const double SquareSurfaceArea = 289d;
        private const double RectangleHeight = 23d;
        private const double RectangleWidth = 67d;
        private const double RectangleSurfaceArea = 1541d;

        private class ConsoleMock : IConsole
        {
            private readonly Queue<string> entries;
            public List<string> Output { get; } = new List<string>();
            public ConsoleMock(params string[] entries)
            {
                this.entries = new Queue<string>(entries);
            }

            public ConsoleKeyInfo ReadKey() => default;

            public string ReadLine() => entries.Dequeue();

            public void WriteLine(string text) => Output.Add(text);
        }


        [TestMethod]
        public void CalculateSurfaceAreas()
        {
            // Arrange
            var console = new ConsoleMock(
                $"create triangle {TriangleHeight} {TriangleWidth}",
                $"create circle {CircleRadius}",
                $"create square {SquareSide}",
                $"create rectangle {RectangleHeight} {RectangleWidth}",
                "calculate",
                "print",
                "reset",
                "print",
                "exit");
            var sut = new SurfaceAreaCalculator(console);

            // Act
            sut.Start();

            // Assert
            var output = console.Output;
            Assert.AreEqual("commands:", output[0]);
            Assert.AreEqual("- create square {double} (create a new square)", output[1]);
            Assert.AreEqual("- create circle {double} (create a new circle)", output[2]);
            Assert.AreEqual("- create rectangle {height} {width} (create a new rectangle)", output[3]);
            Assert.AreEqual("- create triangle {height} {width} (create a new triangle)", output[4]);
            Assert.AreEqual("- print (print the calculated surface areas)", output[5]);
            Assert.AreEqual("- calculate (calulate the surface areas of the created shapes)", output[6]);
            Assert.AreEqual("- reset (reset)", output[7]);
            Assert.AreEqual("- exit (exit the loop)", output[8]);
            Assert.AreEqual("Triangle created!", output[9]);
            Assert.AreEqual("Circle created!", output[10]);
            Assert.AreEqual("Square created!", output[11]);
            Assert.AreEqual("Rectangle created!", output[12]);
            Assert.AreEqual($"- [0] triangle surface area is {TriangleSurfaceArea}\r\n- [1] circle surface area is {CircleSurfaceArea}\r\n- [2] square surface area is {SquareSurfaceArea}\r\n- [3] rectangle surface area is {RectangleSurfaceArea}", output[13]);
            Assert.AreEqual("Reset state!!", output[14]);
            Assert.AreEqual("There are no surface areas to print", output[15]);
        }
    }
}
