using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    public static class day7
    {
        public static void Solution1()
        {
            var Data = InitData();

            var Start = Data.Min();
            var FuelCost = 10000000;
            var Optimal = false;

            while (!Optimal)
            {
                var TmpFuel = 0;
                for (int i = 0; i < Data.Count; i++)
                {
                    TmpFuel += Math.Abs(Data[i] - Start);
                }
                
                if (FuelCost < TmpFuel)
                {
                    Console.WriteLine(FuelCost);
                    Optimal = true;
                }
                else
                {
                    FuelCost = TmpFuel;
                }
                Start++;
            }

        }



        public static void Solution2()
        {
            var Data = InitData();
            var FuelCost = 0;
            var Avg = (int)Data.Average();
            for (int i = 0; i < Data.Count; i++)
            {
                var Diff = Math.Abs(Data[i] - Avg);
                var TriangularNumber = Diff * (Diff + 1) / 2;
                FuelCost += TriangularNumber;
            }

            Console.WriteLine(FuelCost);
        }
        public static List<int> InitData()
        {
            var ProjectFolder = Directory.GetCurrentDirectory();
            var FilePath = Path.Combine(ProjectFolder, @"data\day7.txt");
            var Columns = File.ReadAllText(FilePath).Split(",");

            var Output = new List<int>();

            for (int i = 0; i < Columns.Length; i++)
            {
                Output.Add(int.Parse(Columns[i]));
            }

            return Output;
        }
    }
}
