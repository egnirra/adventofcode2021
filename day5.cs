using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    public static class day5
    {
        public static void Solution1()
        {
            var Data = InitData();
            
            var Array2D = new int[1000,1000];

            foreach (var d in Data)
            {
                var Distance = 0;
                if (d.x1 == d.x2)
                {
                    var Start = Math.Min(d.y1, d.y2);
                    Distance = Math.Max(d.y1, d.y2) + 1;

                    //if (Start > 0)
                    //    Distance++;

                    for (int i = Start; i < Distance; i++)
                        Array2D[i, d.x1]++;

                }
                
                
                if (d.y1 == d.y2)
                {

                    var Start = Math.Min(d.x1, d.x2);
                    Distance = Math.Max(d.x1, d.x2) + 1;
                    //if (Start > 0)
                    //    Distance++;
                    
                    for (int i = Start; i < Distance; i++)
                    {
                        //Console.WriteLine($"Updating row {i} in Segment {d.y1} ");
                        Array2D[d.y1, i]++;

                    }
                    //Console.WriteLine("hej");
                }

                //Array2D[d.x1][d.y1]
            }
            var Matches = 0;
            foreach (var d in Array2D)
            {
                if (d >= 2)
                {
                    Matches++;
                }
            }

            //foreach (int i in Array2D)
            //{
            //    Console.Write("{0} ", i);
            //}
            Console.WriteLine(Matches);
        }


        public static void Solution2()
        {
            var Data = InitData();


            var Array2D = new int[1000, 1000];

            foreach (var d in Data)
            {
                if (d.x1 == d.x2)
                {
                    var Start = Math.Min(d.y1, d.y2);
                    var End = Math.Max(d.y1, d.y2) + 1;

                    for (int i = Start; i < End; i++)
                        Array2D[i, d.x1]++;

                }
                else if (d.y1 == d.y2)
                {
                    var Start = Math.Min(d.x1, d.x2);
                    var End = Math.Max(d.x1, d.x2) + 1;

                    for (int i = Start; i < End; i++)
                    {
                        Array2D[d.y1, i]++;

                    }
                }
                else
                {
                    
                    var StartY = 0;
                    var StartX = 0;
                    var EndX = 0;

                    if (d.y1 > d.y2)
                    {
                        StartY = d.y2;
                        StartX = d.x2;
                        EndX = d.x1;
                    }
                    else if (d.y1 < d.y2)
                    {
                        StartY = d.y1;
                        StartX = d.x1;
                        EndX = d.x2;
                    }

                    var NegativeInc = new Boolean();
                    if (StartX > EndX)
                        NegativeInc = true;
                    if (StartX < EndX)
                        NegativeInc = false;

                    var Distance = Math.Abs(EndX - StartX);
                    for (int i = 0; i < Distance + 1; i++)
                    {
                            
                        Array2D[StartY, StartX]++;

                        if (!NegativeInc)
                            StartX++;
                        if (NegativeInc)
                            StartX--;
                        StartY++;

                    }

                }

            }
            var Matches = 0;
            foreach (var d in Array2D)
            {
                if (d >= 2)
                {
                    Matches++;
                }
            }

            Console.WriteLine(Matches);


        }

        public struct Point
        {
            public int x1, y1, x2, y2;
        }


        public static List<Point> InitData()
        {
            var ProjectFolder = Directory.GetCurrentDirectory();
            var FilePath = Path.Combine(ProjectFolder, @"data\day5.txt");
            var Columns = File.ReadAllLines(FilePath);
            var Output = new List<Point>();
            foreach (var c in Columns)
            {
                var NewVal = c.Replace(" -> ", ";").Split(";");
                Output.Add(new Point()
                {
                    x1 = int.Parse(NewVal[0].Split(",")[0]),
                    y1 = int.Parse(NewVal[0].Split(",")[1]),
                    x2 = int.Parse(NewVal[1].Split(",")[0]),
                    y2 = int.Parse(NewVal[1].Split(",")[1])

                });


            }

            return Output;
        }
    }
}
