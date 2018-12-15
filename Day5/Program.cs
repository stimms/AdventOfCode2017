using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();
            Console.ReadLine();
        }

        private static void Part1()
        {
            var lines = File.ReadAllLines("input.txt").Select(x => Int32.Parse(x)).ToList();
            var index = 0;
            int i = 0;
            while (index < lines.Count() && index >= 0)
            {
                var newIndex = index + lines[index];
                lines[index]++;
                i++;
                index = newIndex;
            }

            Console.WriteLine(i);
        }
        private static void Part2()
        {
            var lines = File.ReadAllLines("input.txt").Select(x => Int32.Parse(x)).ToList();
            var index = 0;
            int i = 0;
            while (index < lines.Count() && index >= 0)
            {
                var newIndex = index + lines[index];
                if (lines[index] >= 3)
                {
                    lines[index]--;
                }
                else
                {
                    lines[index]++;
                }

                i++;
                index = newIndex;
            }

            Console.WriteLine(i);
        }
    }
}
