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
            var values = File.ReadAllLines("input.txt").First().Split("\t").Select(x=>Int32.Parse(x)).ToList();

            var seen = new HashSet<string>();
            int i = 0;
            bool firstSeen = false;
            while (true)
            {
                i++;
                var max = values.Max();
                var index = values.IndexOf(max);
                values[index] = 0;
                for(int j = index+1; j < max+index+1; j++)
                {
                    values[j % values.Count]++;
                }
                var value = String.Join(",", values.Select(x => x.ToString()));
                if (seen.Contains(value))
                {
                    if (!firstSeen)
                    {
                        firstSeen = true;
                        seen.Clear();
                        Console.WriteLine(i);
                    }
                    else
                    {
                        break;
                    }
                }
                seen.Add(value);
            }
            Console.WriteLine(i);
            Console.ReadLine();
        }

    }
}
