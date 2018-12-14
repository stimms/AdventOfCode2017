using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Day3


{
    class Program
    {
        static void Main(string[] args)
        {
            var input = 289326;
            Part1(input);
            Part2(input);
            Console.ReadLine();
        }

        private static void Part2(int input)
        {
            var numbers = new int[500, 500];
            for (int i = 0; i < 500; i++)
            {
                for (int j = 0; j < 500; j++)
                {
                    numbers[i, j] = 0;
                }
            }

            var lastNumber = 1;
            var x = 251;
            var y = 250;
            numbers[250, 250] = 1;

            var ringNumber = 1;
            var populatedInRing = 0;
            do
            {
                numbers[x, y] = numbers[x - 1, y] + numbers[x + 1, y] + numbers[x, y - 1] + numbers[x, y + 1] + numbers[x + 1, y + 1] + numbers[x + 1, y - 1] + numbers[x - 1, y + 1] + numbers[x - 1, y - 1];
                lastNumber = numbers[x, y];
                var numberEachSide = 1 + (ringNumber * 2);
                int numberInRing = (numberEachSide * 4) - 4;

                populatedInRing++;
                if (populatedInRing == numberInRing)
                {
                    ringNumber++;
                    populatedInRing = 0;
                    x = x + 1;
                    continue;
                }
                if (populatedInRing < ringNumber * 2)
                {
                    y--;
                }
                else if (populatedInRing < ringNumber * 2 + numberEachSide - 1)
                {
                    x--;
                }
                else if (populatedInRing < ringNumber * 2 + 2 * (numberEachSide - 1))
                {
                    y++;
                }
                else
                {
                    x++;
                }

                //Console.WriteLine($"({x},{y})");

            } while (lastNumber <= input);
            Console.WriteLine(lastNumber);
        }

        private static void Part1(int input)
        {
            var rings = new List<(int start, int end)>();
            rings.Add((1, 1));
            rings.Add((2, 9));
            for (int i = 2; i < 2000; i++)
            {
                (int start, int end) previous = rings[i - 1];
                rings.Add((previous.end + 1, previous.end + (previous.end - previous.start + 8 + 1)));
            }
            var ring = rings.Single(x => x.start <= input && x.end >= input);
            var ringNumber = rings.IndexOf(ring);
            var numberEachSide = 1 + (ringNumber * 2);
            var midpoints = new List<int> { ring.start + ringNumber - 1, ring.start + ringNumber - 1 + numberEachSide - 1, ring.start + ringNumber - 1 + (numberEachSide * 2) - 2, ring.start + ringNumber - 1 + (numberEachSide * 3) - 3 };
            var closetMidPointDistance = midpoints.Select(x => Math.Abs(x - input)).Min();
            Console.WriteLine(closetMidPointDistance + ringNumber);
        }
    }
}
