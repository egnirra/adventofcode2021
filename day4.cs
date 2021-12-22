using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    public static class day4
    {
        public static void Solution1()
        {

            var LottoData = InitData();
            var BingoRows = 0;
            var BingoColumns = 0;
            var PickedNumber = 0;

            var WinningBoard = 0;
            for (int i = 0; i < LottoData.LottoNumbers.Count; i++)
            {
                for (int b = 0; b < LottoData.LottoBoards.Count; b++)
                {
                    for (int r = 0; r < 5; r++)
                    {
                        BingoColumns = 0;
                        BingoRows = 0;
                        for (int d = 0; d < 5; d++)
                        {
                            //Checking rows
                            if (LottoData.LottoNumbers[i] == LottoData.LottoBoards[b].BoardNumbers.Numbers[r, d]) 
                                LottoData.LottoBoards[b].BoardNumbers.Bingo[r, d] = BingoValues.Yes;

                            if (LottoData.LottoBoards[b].BoardNumbers.Bingo[r, d] == BingoValues.Yes)
                                BingoRows++;

                            //Checking columns
                            if (LottoData.LottoNumbers[i] == LottoData.LottoBoards[b].BoardNumbers.Numbers[d, r])
                                LottoData.LottoBoards[b].BoardNumbers.Bingo[d, r] = BingoValues.Yes;

                            if (LottoData.LottoBoards[b].BoardNumbers.Bingo[d, r] == BingoValues.Yes)
                                BingoColumns++;

                            if (BingoRows == 5 || BingoColumns == 5)
                            {
                                Console.WriteLine($"Winning board! {b}");
                                PickedNumber = LottoData.LottoNumbers[i];
                                WinningBoard = b;
                                break;
                            }
                        }
                        if (BingoRows == 5 || BingoColumns == 5)
                            break;
                     }

                    if (BingoRows == 5 || BingoColumns == 5)
                        break;
                }

                if (BingoRows == 5 || BingoColumns == 5)
                    break;
            }

            var MarkedNumbers = new List<int>();
            var UnmarkedNumbers = new List<int>();
            for (int r = 0; r < 5; r++)
            {
                for (int d = 0; d < 5; d++)
                {
                    if (LottoData.LottoBoards[WinningBoard].BoardNumbers.Bingo[r, d] == BingoValues.Yes)
                        MarkedNumbers.Add(LottoData.LottoBoards[WinningBoard].BoardNumbers.Numbers[r, d]);

                    if (LottoData.LottoBoards[WinningBoard].BoardNumbers.Bingo[r, d] == BingoValues.No)
                        UnmarkedNumbers.Add(LottoData.LottoBoards[WinningBoard].BoardNumbers.Numbers[r, d]);


                }
            }
            Console.WriteLine(UnmarkedNumbers.Sum() * PickedNumber);
    
        }

        public static void Solution2()
        {
            var LottoData = InitData();
            var BingoRows = 0;
            var BingoColumns = 0;
            var PickedNumber = 0;

            var WinningBoard = 0;
            for (int i = 0; i < LottoData.LottoNumbers.Count; i++)
            {
                for (int b = 0; b < LottoData.LottoBoards.Count; b++)
                {
                    if (LottoData.LottoBoards[b].BoardNumbers.Win is false)
                    {
                        for (int r = 0; r < 5; r++)
                        {
                            BingoColumns = 0;
                            BingoRows = 0;
                            for (int d = 0; d < 5; d++)
                            {
                                //Checking rows
                                if (LottoData.LottoNumbers[i] == LottoData.LottoBoards[b].BoardNumbers.Numbers[r, d])
                                    LottoData.LottoBoards[b].BoardNumbers.Bingo[r, d] = BingoValues.Yes;

                                if (LottoData.LottoBoards[b].BoardNumbers.Bingo[r, d] == BingoValues.Yes)
                                    BingoRows++;

                                //Checking columns
                                if (LottoData.LottoNumbers[i] == LottoData.LottoBoards[b].BoardNumbers.Numbers[d, r])
                                    LottoData.LottoBoards[b].BoardNumbers.Bingo[d, r] = BingoValues.Yes;

                                if (LottoData.LottoBoards[b].BoardNumbers.Bingo[d, r] == BingoValues.Yes)
                                    BingoColumns++;

                                if (BingoRows == 5 || BingoColumns == 5)
                                {
                                    PickedNumber = LottoData.LottoNumbers[i];
                                    LottoData.LottoBoards[b].BoardNumbers.Win = true;
                                    WinningBoard = b;
                                    break;
                                }
                            }
                            if (BingoRows == 5 || BingoColumns == 5)
                                break;
                        }
                    }
                    
                }

            }

            var MarkedNumbers = new List<int>();
            var UnmarkedNumbers = new List<int>();
            for (int r = 0; r < 5; r++)
            {
                for (int d = 0; d < 5; d++)
                {
                    if (LottoData.LottoBoards[WinningBoard].BoardNumbers.Bingo[r, d] == BingoValues.Yes)
                        MarkedNumbers.Add(LottoData.LottoBoards[WinningBoard].BoardNumbers.Numbers[r, d]);

                    if (LottoData.LottoBoards[WinningBoard].BoardNumbers.Bingo[r, d] == BingoValues.No)
                        UnmarkedNumbers.Add(LottoData.LottoBoards[WinningBoard].BoardNumbers.Numbers[r, d]);

                }
            }
            Console.WriteLine(UnmarkedNumbers.Sum() * PickedNumber);
        }

        public record Data
        {
            public List<int>? LottoNumbers;
            public List<LottoBoard>? LottoBoards;

        }

        public record LottoBoard
        {
            public BoardNumber? BoardNumbers;
        }

        public record BoardNumber
        {
            public int[,]? Numbers { get; set; }
            public BingoValues[,]? Bingo { get; set; }
            public bool? Win { get; set; }
        }

        public enum BingoValues
        {
            No = 0,
            Yes = 1
        }
        public static Data InitData()
        {
            var ProjectFolder = Directory.GetCurrentDirectory();
            var FilePath = Path.Combine(ProjectFolder, @"data\day4.txt");
            var Columns = File.ReadAllLines(FilePath);
            var data = new Data()
            {
                LottoNumbers = new List<int>(),
                LottoBoards = new List<LottoBoard>()
            };

            foreach (var Column in Columns[0].Split(","))
            {

                data.LottoNumbers.Add(int.Parse(Column));
            }
            var Loop = 0;
            foreach (var Column in Columns[1..])
            {
                if (Loop == 5)
                    Loop = 0;

                if (string.IsNullOrWhiteSpace(Column))
                {

                    data.LottoBoards.Add(new LottoBoard() {
                        BoardNumbers = new BoardNumber() {
                            Numbers = new int[5, 5],
                            Bingo = new BingoValues[5,5],
                            Win = new bool()
                        }});;

                }
                if (!string.IsNullOrWhiteSpace(Column))
                {
                    var Split = Column.Replace("  ", " ").Split(" ");
                    if (string.IsNullOrWhiteSpace(Split[0]))
                    {
                        Split = Split[1..];
                    }

                    var Parse = new int[Split.Length];
                    var Index = data.LottoBoards.Count - 1;

                    for (int i = 0; i < Parse.Length; i++)
                    {
                        data.LottoBoards[Index].BoardNumbers.Numbers[Loop, i] = int.Parse(Split[i]);
                    }

                    Loop++;

                }

            }
            return data;
        }
    }



}
