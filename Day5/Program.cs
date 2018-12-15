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
            var lines = File.ReadAllLines("input.txt").Select(x=>Int32.Parse(x));
            var sum = 0;
            foreach (var line in lines)
            {
                var numbers = line.Split("\t").Select(x => Int32.Parse(x));
                sum += numbers.Max() - numbers.Min();
            }
            Console.WriteLine(sum);

            sum = 0;
            foreach (var line in lines)
            {
                var numbers = line.Split("\t").Select(x => Int32.Parse(x)).ToList();
                var combined = numbers.AllCombinations(numbers);
                var even = combined.Where(x => x.Item1 % x.Item2 == 0 && x.Item1 != x.Item2).Single();
                sum += even.Item1 / even.Item2;
            }

            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}
