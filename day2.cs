using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    public static class day2
    {
        public static int horizontal;
        public static int depth;

        public static void Solution1()
        {
            var ProjectFolder = Directory.GetCurrentDirectory();
            var file = Path.Combine(ProjectFolder, @"data\day2.txt");
            foreach (var i in File.ReadAllLines(file))
            {
                var test = i switch
                {
                    var h when h.Contains("forward") => horizontal += int.Parse(i[^1..]),
                    var d when d.Contains("down") => depth += int.Parse(i[^1..]),
                    var u when u.Contains("up") => depth -= int.Parse(i[^1..]),
                    _ => 0
                };
                
            }

            Console.WriteLine(horizontal * depth);
        }

        public static int aim;

        public static void Solution2()
        {
            horizontal = 0;
            depth = 0;
            aim = 0;
            var projectFolder = Directory.GetCurrentDirectory();
            var file = Path.Combine(projectFolder, @"data\day2.txt");
            foreach (var i in File.ReadAllLines(file))
            {
                var value = int.Parse(i[^1..]);
                if (i.Contains("forward"))
                {
                    horizontal += value;
                    if (aim > 0)
                        depth += aim * value;
                }
                if (i.Contains("down"))
                {
                    //depth += value;
                    aim += value;
                }
                if (i.Contains("up"))
                {
                    //depth -= value;
                    aim -= value;
                }

            }
            Console.WriteLine($"Horizontal: {horizontal}\nDepth: {depth}\nAim: {aim}");
            Console.WriteLine($"Final Position: {horizontal * depth }");
        }
    }
}
