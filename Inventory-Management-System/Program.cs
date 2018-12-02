using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Common;

namespace Inventory_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = GetInput();
            Problem1(input);
            //Problem2();
        }

        private static void Problem1(IList<Id> items)
        {
            // first part of puzzle
            var appears2TimesCount = items.Count(id => id.HasOfAnyLetter(2));
            var appears3TimesCount = items.Count(id => id.HasOfAnyLetter(3));
            Console.WriteLine($"Checksum for {appears2TimesCount} * {appears3TimesCount} = {appears2TimesCount* appears3TimesCount}");
        }

        private static IList<Id> GetInput()
        {
            var items = new List<Id>();
            var fileProcessor = new FileProcessor();
            var filePath = Directory.GetCurrentDirectory() + "/input.txt";
            fileProcessor.ReadFilePerLine(filePath, (line) =>
            {
                items.Add(new Id(line));
            });
            return items;
        }
    }
}
