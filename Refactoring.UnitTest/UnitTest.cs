namespace Refactoring.UnitTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Refactoring;
    using System;
    using System.Collections.Generic;
    using System.Text;

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
        private const double RhombusHeight = 13d;
        private const double RhombusWidth = 34d;
        private const double RhombusSurfaceArea = 442d;

        private class ConsoleMock : IConsole
        {
            private readonly Queue<string> entries;
            public StringBuilder Output { get; } = new StringBuilder();
            public ConsoleMock(params string[] entries)
            {
                this.entries = new Queue<string>(entries);
            }

            public ConsoleKeyInfo ReadKey() => default;

            public string ReadLine() => entries.Dequeue();

            public void WriteLine(string text) => Output.AppendLine(text);
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
                $"create rhombus {RhombusHeight} {RhombusWidth}",
                "calculate",
                "print",
                "reset",
                "print",
                "exit");
            var sut = new SurfaceAreaCalculator(console);

            // Act
            sut.Start();

            // Assert
            var output = console.Output.ToString();
            Assert.IsTrue(output.Contains("commands:"));
            Assert.IsTrue(output.Contains("- create square {double} (create a new square)"));
            Assert.IsTrue(output.Contains("- create circle {double} (create a new circle)"));
            Assert.IsTrue(output.Contains("- create rectangle {height} {width} (create a new rectangle)"));
            Assert.IsTrue(output.Contains("- create triangle {height} {width} (create a new triangle)"));
            Assert.IsTrue(output.Contains("- create rhombus {height} {base} (create a new rhombus)"));
            Assert.IsTrue(output.Contains("- print (print the calculated surface areas)"));
            Assert.IsTrue(output.Contains("- calculate (calulate the surface areas of the created shapes)"));
            Assert.IsTrue(output.Contains("- reset (reset)"));
            Assert.IsTrue(output.Contains("- exit (exit the loop)"));
            Assert.IsTrue(output.Contains("Triangle created!"));
            Assert.IsTrue(output.Contains("Circle created!"));
            Assert.IsTrue(output.Contains("Square created!"));
            Assert.IsTrue(output.Contains("Rectangle created!"));
            Assert.IsTrue(output.Contains("Rhombus created!"));
            Assert.IsTrue(output.Contains($"triangle surface area is {TriangleSurfaceArea}"));
            Assert.IsTrue(output.Contains($"circle surface area is {CircleSurfaceArea}"));
            Assert.IsTrue(output.Contains($"square surface area is {SquareSurfaceArea}"));
            Assert.IsTrue(output.Contains($"rectangle surface area is {RectangleSurfaceArea}"));
            Assert.IsTrue(output.Contains($"rhombus surface area is {RhombusSurfaceArea}"));
            Assert.IsTrue(output.Contains("Reset state!!"));
            Assert.IsTrue(output.Contains("There are no surface areas to print"));
        }
    }
}
