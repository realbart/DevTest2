using System;
using System.Text;

namespace Refactoring
{
    public class SurfaceAreaCalculator
    {
        readonly StringBuilder shapes = new StringBuilder();
        private readonly IConsole console;
        int shapesCount = 0;

        public SurfaceAreaCalculator(IConsole console) => this.console = console;

        public void Start()
        {
            ShowCommands();
            while (true)
            {
                var arguments = console.ReadLine().Split(' ');
                switch (arguments[0])
                {
                    case "create":
                        if (arguments.Length > 1)
                            switch (arguments[1])
                            {
                                case "circle":
                                    var circleSurface = Math.Round(Math.PI * Math.Pow(double.Parse(arguments[2]), 2), 2);
                                    shapes.AppendLine($"- [{shapesCount++}] circle surface area is {circleSurface}");
                                    console.WriteLine("Circle created!");
                                    continue;
                                case "square":
                                    var squareSurface = Math.Pow(double.Parse(arguments[2]), 2);
                                    shapes.AppendLine($"- [{shapesCount++}] square surface area is {squareSurface}");
                                    console.WriteLine("Square created!");
                                    continue;
                                case "rectangle":
                                    var rectangleSurface = double.Parse(arguments[2]) * double.Parse(arguments[3]);
                                    shapes.AppendLine($"- [{shapesCount++}] rectangle surface area is {rectangleSurface}");
                                    console.WriteLine("Rectangle created!");
                                    continue;
                                case "triangle":
                                    var triangleSurface = 0.5d * double.Parse(arguments[2]) * double.Parse(arguments[3]);
                                    shapes.AppendLine($"- [{shapesCount++}] triangle surface area is {triangleSurface}");
                                    console.WriteLine("Triangle created!");
                                    continue;
                            }
                        break;
                    case "calculate":
                        continue;
                    case "print":
                        console.WriteLine(shapesCount == 0 ? "There are no surface areas to print" : shapes.ToString().TrimEnd('\r', '\n'));
                        continue;
                    case "reset":
                        shapesCount = 0;
                        shapes.Clear();
                        console.WriteLine("Reset state!!");
                        continue;
                    case "exit":
                        return;
                    default:
                        console.WriteLine("Unknown command!!!");
                        break;
                }
                ShowCommands();
            }
        }

        public void ShowCommands()
        {
            console.WriteLine("commands:");
            console.WriteLine("- create square {double} (create a new square)");
            console.WriteLine("- create circle {double} (create a new circle)");
            console.WriteLine("- create rectangle {height} {width} (create a new rectangle)");
            console.WriteLine("- create triangle {height} {width} (create a new triangle)");
            console.WriteLine("- print (print the calculated surface areas)");
            console.WriteLine("- calculate (calulate the surface areas of the created shapes)");
            console.WriteLine("- reset (reset)");
            console.WriteLine("- exit (exit the loop)");
        }
    }
}