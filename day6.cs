using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    public static class day6
    {
        public static void Solution1(long Days)
        {
            var Data = InitData();
            for (int i = 0; i < Days; i++)
            {
                long newFish = Data[0];
                Data[0] = Data[1];
                Data[1] = Data[2];
                Data[2] = Data[3];
                Data[3] = Data[4];
                Data[4] = Data[5];
                Data[5] = Data[6];
                Data[6] = Data[7];
                Data[7] = Data[8];
                Data[8] = newFish;
                Data[6] += newFish;
            }
            Console.WriteLine(Data.Sum());
        }


        public static long[] InitData()
        {
            var ProjectFolder = Directory.GetCurrentDirectory();
            var FilePath = Path.Combine(ProjectFolder, @"data\day6.txt");
            var Columns = File.ReadAllText(FilePath).Split(",");
            var Output = new long[9];
            foreach (var c in Columns)
            {
                var Input = long.Parse(c);
                Output[Input]++;
            }

            return Output;
        }
    }
}
