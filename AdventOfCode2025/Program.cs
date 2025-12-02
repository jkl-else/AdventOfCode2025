using System.Diagnostics;
using AdventOfCode2025.Calendar.D02;

namespace AdventOfCode2025
{
    internal static class Program
    {
        static async Task Main()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"Running day: {Path.GetExtension(typeof(Part1).Namespace)![2..]}{Environment.NewLine}");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var type in new[] { typeof(Part1), typeof(Part2) })
            {
                // Build file path based on type and file
                var day = (type.Namespace ?? string.Empty).Split('.').Last(); // e.g., D01
                foreach (var file in new[] { "Test", "Input" })
                {
                    try
                    {
                        var filePath = Path.Combine("Calendar", day, $"{file}.txt");
                        if (!File.Exists(filePath) || new FileInfo(filePath).Length == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{file} - {type.Name} has no data!");
                            continue;
                        }

                        // Create instance
                        var instance = (Part)Activator.CreateInstance(type)!;
                        // start measure time after instance is created
                        var w = Stopwatch.StartNew();
                        var result = await instance.GetResultAsync(file);
                        w.Stop(); // stop since WriteLine takes time
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{file} - {type.Name}: Result = {result}");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"{file} - {type.Name}: Result in: {w.Elapsed}");
                    }
                    catch (NotImplementedException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{file} - {type.Name} is not Implemented!");
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e);
                    }

                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                }
            }
        }
    }
}
