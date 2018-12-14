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
            var numberEachSide = ((ring.end - ring.start) + 5) / 4;
            var midpoints = new List<int> { ring.start + ringNumber -1, ring.start + ringNumber -1 + numberEachSide -1, ring.start + ringNumber - 1 + (numberEachSide*2) -2, ring.start + ringNumber -1 + (numberEachSide*3) -3};
            var closetMidPointDistance = midpoints.Select(x => Math.Abs(x - input)).Min();
            Console.WriteLine(closetMidPointDistance + ringNumber);
            Console.ReadLine();
        }
    }
}
