using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Day4


{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            var valid = 0;
            foreach (var line in lines)
            {
                var words = line.Split(' ');
                if (words.Distinct().Count() == words.Count())
                    valid++;
            }
            Console.WriteLine(valid);
            foreach (var line in lines)
            {
                var sortedWords = line.Split(' ').Select(x => new String(x.OrderBy(y => y).ToArray()));
                if (sortedWords.Distinct().Count() == sortedWords.Count())
                    valid++;
            }
            Console.WriteLine(valid);
            Console.ReadLine();
        }
    }
}
