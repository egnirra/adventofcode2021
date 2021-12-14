using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    public static class day1
    {
        public static void Solution2()
        {
            var projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            var file = Path.Combine(projectFolder, @"..\data\day1.txt");
            var data = File.ReadAllLines(file);
            var input = new int[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                input[i] = int.Parse(data[i]);
            }
            var lastSum = input[0..3].Sum();
            var count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                var next = i + 3;
                if (i + 3 > input.Length)
                {
                    Console.WriteLine($"{count}");
                    return;
                }
                var currentSum = input[i..next].Sum();
                if (currentSum > lastSum)
                {
                    count++;
                }
                lastSum = currentSum;
            }

        }
    }
}
