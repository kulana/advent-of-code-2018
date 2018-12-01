using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Common;

namespace Chronal_Calibration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IList<int> freqs = GetFrequencies();
            Problem1(freqs);
            Problem2(freqs);
        }

        private static void Problem1(IEnumerable<int> freqs)
        {
            // first part of puzzle
            Console.WriteLine($"Sum of all frequencies is {freqs.Sum()}");
        }

        private static void Problem2(IList<int> freqs)
        {
            var finished = false;
            var calculatedFrequencies = new List<int>();
            var currentFrequency = 0;
            while (!finished)
            {
                foreach (var freq in freqs)
                {
                    currentFrequency += freq;
                    finished = calculatedFrequencies.Contains(currentFrequency);
                    if (finished)
                    {
                        break;
                    }
                    calculatedFrequencies.Add(currentFrequency);
                }
            }

            // second part of puzzle
            Console.WriteLine($"First frequency reached twice is {currentFrequency}");
        }

        private static IList<int> GetFrequencies()
        {
            var freqs = new List<int>();
            var fileProcessor = new FileProcessor();
            var filePath = Directory.GetCurrentDirectory() + "/input.txt";
            fileProcessor.ReadFilePerLine(filePath, (line) =>
            {
                var freq = Parser.Parse(line);
                freqs.Add(freq);
            });
            return freqs;
        }
    }
}
