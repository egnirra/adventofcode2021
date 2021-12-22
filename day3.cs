using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    public static class day3
    {
        public static void Solution1()
        {
            var ProjectFolder = Directory.GetCurrentDirectory();
            var file = Path.Combine(ProjectFolder, @"data\day3.txt");
            var columns = File.ReadAllLines(file);

            var GammaRate = new List<int>();
            var Epsilonrate = new List<int>();


            for (int i = 0; i < columns[0].Length; i++)
            {
                var zeroes = 0;
                var ones = 0;
                for (int c = 0; c < columns.Length; c++)
                {
                    var column = columns[c][i];
                    if (column == "0".ToCharArray()[0])
                        zeroes++;
                    if (column == "1".ToCharArray()[0])
                        ones++;
                }
                if (zeroes > ones)
                    GammaRate.Add(0);
                if (zeroes < ones)
                    GammaRate.Add(1);
                if (zeroes < ones)
                    Epsilonrate.Add(0);
                if (zeroes > ones)
                    Epsilonrate.Add(1);

            }
       


            var GammaDecimal = Convert.ToInt32(string.Join(string.Empty, GammaRate), 2);
            var EpsilonDecimal = Convert.ToInt32(string.Join(string.Empty, Epsilonrate), 2);

            Console.WriteLine(EpsilonDecimal);
            Console.WriteLine(GammaDecimal);
            Console.WriteLine($"Epsilon * Gamma: {EpsilonDecimal * GammaDecimal}");
        }


        public static void Solution2()
        {
            var projectFolder = Directory.GetCurrentDirectory();
            var file = Path.Combine(projectFolder, @"data\day3.txt");
            var columns = File.ReadAllLines(file).ToList();
            var columns2 = File.ReadAllLines(file).ToList();

            var zeroescolumns = new List<char>();
            var tempcol = new List<string>();
            tempcol.AddRange(columns);


            for (int i = 0; i < columns[0].Length; i++) // Iterate through the number of characters/numbers in the line
            {
                var zeroes = 0;
                var ones = 0;
                for (int c = 0; c < columns.Count; c++) // Check each line in the position of "i" for 0 or 1 to see which is bigger
                {
                    var column = columns[c][i];
                    if (column == "0"[0])
                        zeroes++;
                    if (column == "1"[0])
                        ones++;
                }
                for (int d = 0; d < columns.Count; d++) // Go through all lines and check if the column of "i" position contains 0/1 and delete the value
                {
                    if (ones > zeroes && columns[d][i] == "0"[0])
                    {
                        columns.Remove(columns[d]);
                        d--; //column.count changes as we delete, need to decrease here to make the count accurate
                    }
                    
                    if (zeroes > ones && columns[d][i] == "1"[0])
                    {
                        columns.Remove(columns[d]);
                        d--;
                    }
                    if (zeroes == ones && columns[d][i] == "0"[0])
                    {                    
                        columns.Remove(columns[d]);
                        d--;
                    }
                }
                

            }


            for (int i = 0; i < columns2[0].Length; i++) // Iterate through the number of characters/numbers in the line
            {
                var zeroes = 0;
                var ones = 0;
                for (int c = 0; c < columns2.Count; c++) // Check each line in the position of "i" for 0 or 1 to see which is bigger
                {
                    var column = columns2[c][i];
                    if (column == "0"[0])
                        zeroes++;
                    if (column == "1"[0])
                        ones++;
                }

                for (int d = 0; d < columns2.Count; d++) // Go through all lines and check if the column of "i" position contains 0/1 and delete the value
                {
                    if (zeroes == 0 | ones == 0)
                    {
                        break;
                    }
                    if (ones < zeroes && columns2[d][i] == "0"[0])
                    {
                        columns2.Remove(columns2[d]);
                        d--; //column.count changes as we delete, need to decrease here to make the count accurate
                    }

                    if (zeroes < ones && columns2[d][i] == "1"[0])
                    {

                        columns2.Remove(columns2[d]);
                        d--;
                    }
                    if (zeroes == ones && columns2[d][i] == "1"[0])
                    {
                        columns2.Remove(columns2[d]);
                        d--;
                    }
                    
                }


            }

            var c02 = Convert.ToInt32(columns[0], 2);
            var lifesupp = Convert.ToInt32(columns2[0], 2);

            Console.WriteLine($"C02*lifesupp: {c02 * lifesupp}");
            
        }
    }
} 
