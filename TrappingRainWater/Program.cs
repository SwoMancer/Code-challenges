using Microsoft.VisualBasic;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using static TrappingRainWater.Garden;

namespace TrappingRainWater { 
    public class Program 
    {
        //Starts main to async…
        public static Task Main(string[] args) => new Program().MainAsync(); 
        public async Task MainAsync() 
        {
            //Read inputs…
            string[] inputs = Console.ReadLine().Split(' ', StringSplitOptions.TrimEntries);
            ushort x = ushort.Parse(inputs[0]), ny = ushort.Parse(inputs[1]);

            //Create a garden and populate a garden with input data.
            Garden garden = new Garden(ny, x);
            for (ushort y = 0; y < ny; y++)
            {
                string[] xInputs = Console.ReadLine().Split(' ', StringSplitOptions.TrimEntries);

                garden.AddXLine(y, ConvertStringToUshort(xInputs));
            }

            //Find cells walls...
            garden.ScanTerrain();
            //Find Pool cells...
            garden.FindPoolCells();
            //Print quantity of pool cells...
            garden.Pools();
        }
        /// <summary>
        /// Convert a string to ushort array.
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        private static ushort[] ConvertStringToUshort(string[] inputs)
        {
            ushort[] outputs = new ushort[inputs.Length];

            for (ushort i = 0; i < inputs.Length; i++)
            {
                outputs[i] = ushort.Parse(inputs[i]);
            }
            return outputs;
        }
        #region Test code
        /*
        private async void Test()
        {
            Random random = new Random();
            string data;
            
            Console.WriteLine("===========Test 6============");
            data = "2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2";
            Tester(15, 15, Confier(data));

            Console.WriteLine("===========Test 6.1-1============");
            data = "1 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2";
            Tester(15, 15, Confier(data));

            Console.WriteLine("===========Test 6.1-2============");
            data = "2 2 2 2 2 2 2 2 2 2 2 2 2 2 1\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2";
            Tester(15, 15, Confier(data));

            Console.WriteLine("===========Test 6.1-3============");
            data = "2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n1 2 2 2 2 2 2 2 2 2 2 2 2 2 2";
            Tester(15, 15, Confier(data));

            Console.WriteLine("===========Test 6.1-4============");
            data = "2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 1";
            Tester(15, 15, Confier(data));

            Console.WriteLine("===========Test 6.1-3============");
            data = "2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 1 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2";
            Tester(15, 15, Confier(data));

            Console.WriteLine("===========Test 7============");
            data = "2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2\n2 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 2\n2 1 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 1 2\n2 1 2 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 2 1 2\n2 1 2 1 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 1 2 1 2\n2 1 2 1 2 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 2 1 2 1 2\n2 1 2 1 2 1 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 1 2 1 2 1 2\n2 1 2 1 2 1 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 1 2 1 2 1 2\n2 1 2 1 2 1 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 1 2 1 2 1 2\n2 1 2 1 2 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 2 1 2 1 2\r\n2 1 2 1 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 1 2 1 2\n2 1 2 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 2 1 2\n2 1 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 1 2\n2 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 2\n2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2";
            Tester1(55, 15, Confier(data));
            
            Console.WriteLine("===========Test 8============");
            Tester3(157, 157);

            
            Console.WriteLine("=======================");
            Tester2(10, 10, 0, 999, random);
            Tester2(100, 100, 0, 999, random);
            Tester2(200, 200, 0, 999, random);
            Tester2(300, 300, 0, 999, random);
            Tester2(400, 400, 0, 999, random);
            Tester2(500, 500, 0, 999, random);

            
            Tester2(500, 500, 0, 0, random);
            Tester2(500, 500, 0, 1, random);
            Tester2(500, 500, 0, 2, random);
            
        }
        private void Tester3(int height, int wight)
        {
            string data = "";
            int i = 0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < wight; x++)
                {
                    data += "" + i++;
                    if (x != wight-1)
                        data += " ";

                    if (i > 1)
                        i = 0;
                }
                if (y != height-1)
                    data += "\n";
            }
            Tester1((ushort)height, (ushort)wight, Confier(data));
        }
        public static void Tester2(int y, int x, int hightLow, int hightMax, Random random)
        {
            var watch = new System.Diagnostics.Stopwatch();
            Console.WriteLine("==========" + x + " " + y + "===========");
            watch.Start();
            Garden garden = new Garden((ushort)y, (ushort)x);

            for (int ty = 0; ty < y; ty++)
            {
                ushort[] line = new ushort[x];
                for (int tx = 0; tx < x; tx++)
                {
                    line[tx] = (ushort)random.Next(hightLow, hightMax);
                }

                garden.AddXLine((ushort)ty, line);
            }
            garden.ScanTerrain();
            garden.FindPoolCells();
            garden.Pools();
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds + "ms");
        }
        public async void Tester(ushort x, ushort y, ushort[][] input)
        {
            Garden garden = new Garden(y, x);
            for (ushort ny = 0; ny < input.Length; ny++)
            {
                garden.AddXLine(ny, input[ny]);
            }
            garden.ScanTerrain();
            garden.FindPoolCells();
            garden.Print();
        }
        public async void Tester1(ushort x, ushort y, ushort[][] input)
        {
            Garden garden = new Garden(y, x);
            for (ushort ny = 0; ny < input.Length; ny++)
            {
                garden.AddXLine(ny, input[ny]);
            }
            garden.ScanTerrain();
            garden.FindPoolCells();
            garden.PrintSimpel();
        }
        public static ushort[][] Confier(string input)
        {
            string[] lines = input.Split('\n', StringSplitOptions.TrimEntries);
            ushort[][] outputs = new ushort[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] one = lines[i].Split(' ', StringSplitOptions.TrimEntries);
                ushort[] two = new ushort[one.Length];
                for (int j = 0; j < one.Length; j++)
                {
                    two[j] = ushort.Parse(one[j]);
                }

                outputs[i] = two;
            }
            return outputs;
        }
        */
        #endregion
    }
    #region Garden
    /// <summary>
    /// Defines the <see cref="Garden" />.<br/>
    /// It contains information about the cell grid and is responsible for controlling if there are cells that can collect water.
    /// </summary>
    public class Garden
    {
        #region Fields
        public enum WallType
        {
            Level = 0,
            Higher = 1,
            Lower = -1
        }
        enum Where { Top = 0, Right = 1, Bottom = 2, Left = 3 }
        Cell[][] cells;
        ushort y, x;
        #endregion
        #region Constructor
        public Garden(ushort y, ushort x)
        {
            this.cells = new Cell[y][];
            this.y = y;
            this.x = x;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Add an array of heights of cells on the x axis.
        /// </summary>
        /// <param name="y"></param>
        /// <param name="heights"></param>
        public void AddXLine(ushort y, ushort[] heights)
        {
            List<Cell> localCells = new List<Cell>();

            for (int i = 0; i < heights.Length; i++)
                localCells.Add(new Cell(heights[i]));

            cells[y] = localCells.ToArray();
        }
        /// <summary>
        /// Identify all the cells walls.
        /// </summary>
        public async void ScanTerrain()
        {
            //See if the garden dimension is Greater or equal to 2, then use tasks.
            if (y >= 2 && x >= 2)
            {
                Task<Cell[]>[] taslCells = new Task<Cell[]>[y];

                for (ushort ny = 0; ny < taslCells.Length; ny++)
                {
                    taslCells[ny] = LineWallScan(cells[ny], ny);
                }
                for (ushort ny = 0; ny < taslCells.Length; ny++)
                {
                    cells[ny] = await taslCells[ny];
                }
            }
            else
            {
                //See if first should not be checked
                bool firstShouldBeChecked = true;

                for (ushort y = 0; y < cells.Length; y++)
                {
                    for (ushort x = 0; x < cells[y].Length; x += 2)
                    {
                        if (!firstShouldBeChecked)
                        {
                            x += 1;
                            firstShouldBeChecked = true;
                        }

                        //See if there is a cell on the top.
                        if (y != 0)
                        {
                            WallType wallOnTop = Cell.CompareCellSize(cells[y][x], cells[y - 1][x]);
                            cells[y][x].top = wallOnTop;
                            cells[y - 1][x].bottom = (WallType)((int)wallOnTop * -1);
                        }
                        else
                        {
                            cells[y][x].top = WallType.Higher;
                        }

                        //See if there is a cell to the right.
                        if (x! < cells[y].Length - 1)
                        {
                            WallType wallToRight = Cell.CompareCellSize(cells[y][x], cells[y][x + 1]);
                            cells[y][x].right = wallToRight;
                            cells[y][x + 1].left = (WallType)((int)wallToRight * -1);
                        }
                        else
                        {
                            cells[y][x].right = WallType.Higher;
                        }

                        //See if there is a cell on the bootom.
                        if (y! < cells.Length - 1)
                        {
                            WallType wallUnder = Cell.CompareCellSize(cells[y][x], cells[y + 1][x]);
                            cells[y][x].bottom = wallUnder;
                            cells[y + 1][x].top = (WallType)((int)wallUnder * -1);
                        }
                        else
                        {
                            cells[y][x].bottom = WallType.Higher;
                        }

                        //See if there is a cell to the left.
                        if (x != 0)
                        {
                            WallType wallToLeft = Cell.CompareCellSize(cells[y][x], cells[y][x - 1]);
                            cells[y][x].left = wallToLeft;
                            cells[y][x - 1].right = (WallType)((int)wallToLeft * -1);
                        }
                        else
                        {
                            cells[y][x].left = WallType.Higher;
                        }

                        if (x == cells[y].Length - 2)
                        {
                            firstShouldBeChecked = false;
                            break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Identify all the cells walls in a x axis.
        /// </summary>
        /// <param name="cells"></param>
        /// <param name="ny"></param>
        /// <returns></returns>
        private async Task<Cell[]> LineWallScan(Cell[] cells, ushort ny)
        {
            int nx = 0;

            for (nx = 0; nx < cells.Length; nx++)
            {
                //If top
                if (ny == 0)
                {
                    cells[nx].top = WallType.Higher;
                }
                else
                {
                    //If it's not the first line in y-axis, there are neighbours cells on top.
                    if (this.cells[ny - 1][nx].height == cells[nx].height)
                    {
                        cells[nx].top = WallType.Level;
                    }
                    else if(this.cells[ny - 1][nx].height > cells[nx].height)
                    {
                        cells[nx].top = WallType.Higher;
                    }
                    else
                    {
                        cells[nx].top = WallType.Lower;
                    }
                }

                //If bottom
                if (ny == this.cells.Length - 1)
                {
                    cells[nx].bottom = WallType.Higher;
                }
                else
                {
                    //If it is not the last line in y-axis, there are neighbours cells below.
                    if (this.cells[ny + 1][nx].height == cells[nx].height)
                    {
                        cells[nx].bottom = WallType.Level;
                    }
                    else if (this.cells[ny + 1][nx].height > cells[nx].height)
                    {
                        cells[nx].bottom = WallType.Higher;
                    }
                    else
                    {
                        cells[nx].bottom = WallType.Lower;
                    }
                }

                //If left
                if (nx == 0)
                {
                    cells[nx].left = WallType.Higher;
                }
                else
                {
                    //If it is not the first value in the x-axis, then there are neighbours cells to left.
                    if (this.cells[ny][nx - 1].height == cells[nx].height)
                    {
                        cells[nx].left = WallType.Level;
                    }
                    else if (this.cells[ny][nx - 1].height > cells[nx].height)
                    {
                        cells[nx].left = WallType.Higher;
                    }
                    else
                    {
                        cells[nx].left = WallType.Lower;
                    }
                }

                //If right
                if (nx == cells.Length - 1)
                {
                    cells[nx].right = WallType.Higher;
                }
                else
                {
                    //If it is not the last value in the x-axis, then there are neighbours cells to right.
                    if (this.cells[ny][nx + 1].height == cells[nx].height)
                    {
                        cells[nx].right = WallType.Level;
                    }
                    else if (this.cells[ny][nx + 1].height > cells[nx].height)
                    {
                        cells[nx].right = WallType.Higher;
                    }
                    else
                    {
                        cells[nx].right = WallType.Lower;
                    }
                }
            }

            return cells;
        }
        /// <summary>
        /// Print the number of cells that can contain water.
        /// </summary>
        public void Pools()
        {
            int q = 0;
            for (int ny = 0; ny < this.y; ny++)
            {
                for (int nx = 0; nx < this.x; nx++)
                {
                    if (cells[ny][nx].isAPool)
                    {
                        q++;
                    }
                }
            }
            Console.WriteLine(q);
        }
        /// <summary>
        /// 
        /// </summary>
        public async void FindPoolCells()
        {
            //If the garden dimension is lower or equal to two on both axes, Then use the non-task version.
            if (this.y <= 2 && this.x <= 2)
            {
                //Loop dimension...
                for (int ny = 0; ny < y; ny++)
                {
                    for (int nx = 0; nx < x; nx++)
                    {
                        //The cell cannot contain water without leaking the neighbour.             
                        if (cells[ny][nx].top == WallType.Lower || cells[ny][nx].right == WallType.Lower ||
                            cells[ny][nx].bottom == WallType.Lower || cells[ny][nx].left == WallType.Lower)
                        {
                            cells[ny][nx].isAPool = false;
                        }
                    }
                }
                //Loop dimension...
                for (int ny = 0; ny < y; ny++)
                {
                    for (int nx = 0; nx < x; nx++)
                    {
                        //TOP
                        if (cells[ny][nx].top == WallType.Level)
                        {
                            if (!cells[ny][nx].isAPool)
                            {
                                cells[ny - 1][nx].isAPool = false;
                            }
                            else if (!cells[ny - 1][nx].isAPool)
                            {
                                cells[ny][nx].isAPool = false;
                            }
                        }
                        //RIGHT
                        if (cells[ny][nx].right == WallType.Level)
                        {
                            if (!cells[ny][nx].isAPool)
                            {
                                cells[ny][nx + 1].isAPool = false;
                            }
                            else if (!cells[ny][nx + 1].isAPool)
                            {
                                cells[ny][nx].isAPool = false;
                            }
                        }
                        //BOTTOM
                        if (cells[ny][nx].bottom == WallType.Level)
                        {
                            if (!cells[ny][nx].isAPool)
                            {
                                cells[ny + 1][nx].isAPool = false;
                            }
                            else if (!cells[ny + 1][nx].isAPool)
                            {
                                cells[ny][nx].isAPool = false;
                            }
                        }
                        //LEFT
                        if (cells[ny][nx].left == WallType.Level)
                        {
                            if (!cells[ny][nx].isAPool)
                            {
                                cells[ny][nx - 1].isAPool = false;
                            }
                            else if (!cells[ny][nx - 1].isAPool)
                            {
                                cells[ny][nx].isAPool = false;
                            }
                        }
                    }
                }
            }
            else
            { //Use the tasks version if the garden dimension is greater than two on both axes.

                //Create a task for every x-axis.
                Task<Cell[]>[] tasks = new Task<Cell[]>[this.y];

                //Find cells that cannot contain water.
                for (ushort ny = 0; ny < tasks.Length; ny++)
                {
                    tasks[ny] = LineScan(cells[ny], ny);
                } //Wait...
                for (ushort ny = 0; ny < tasks.Length; ny++)
                {
                    cells[ny] = await tasks[ny];
                }

                //Scan neighbour's cells and see if the cell can contain water.
                //Scan from left to right and from top to bottom.
                for (ushort ny = 0; ny < tasks.Length; ny++)
                {
                    tasks[ny] = NeighbourWatch(cells[ny], ny, false);
                }
                for (ushort ny = 0; ny < tasks.Length; ny++)
                {
                    cells[ny] = await tasks[ny];
                }

                //Scan neighbour's cells and see if the cell can contain water.
                //Scan from right to left and from bottom to top.
                for (int ny = tasks.Length - 1; ny > -1; ny--)
                {
                    tasks[ny] = NeighbourWatch(cells[ny], (ushort)ny, true);
                }
                for (int ny = tasks.Length - 1; ny > -1; ny--)
                {
                    cells[ny] = await tasks[ny];
                }

                //Scan neighbour's cells and see if the cell can contain water.
                //Scan from right to left and from top to bottom.
                for (ushort ny = 0; ny < tasks.Length; ny++)
                {
                    tasks[ny] = NeighbourWatch(cells[ny], ny, true);
                }
                for (ushort ny = 0; ny < tasks.Length; ny++)
                {
                    cells[ny] = await tasks[ny];
                }

                //Scan neighbour's cells and see if the cell can contain water.
                //Scan from left to right and from bottom to top.
                for (int ny = tasks.Length - 1; ny > -1; ny--)
                {
                    tasks[ny] = NeighbourWatch(cells[ny], (ushort)ny, false);
                }
                for (int ny = tasks.Length - 1; ny > -1; ny--)
                {
                    cells[ny] = await tasks[ny];
                }

            }
        }
        /// <summary>
        /// Scan all cells in the line on the X axis to find cells that can contain water.
        /// </summary>
        /// <param name="cells"></param>
        /// <param name="ny"></param>
        /// <param name="reverse"></param>
        /// <returns></returns>
        private async Task<Cell[]> NeighbourWatch(Cell[] cells, ushort ny, bool reverse)
        {
            //Reverse the scan order
            if (reverse)
            {
                //int ny = tasks.Length - 1; ny > -1; ny--
                for (int nx = cells.Length - 1; nx > -1; nx--)
                {
                    //TOP
                    if (cells[nx].top == WallType.Level)
                    {
                        if (!this.cells[ny - 1][nx].isAPool)
                        {
                            cells[nx].isAPool = false;
                        }
                    }
                    //RIGHT
                    if (cells[nx].right == WallType.Level)
                    {
                        if (!this.cells[ny][nx + 1].isAPool)
                        {
                            cells[nx].isAPool = false;
                        }
                    }
                    //BOTTOM
                    if (cells[nx].bottom == WallType.Level)
                    {
                        if (!this.cells[ny + 1][nx].isAPool)
                        {
                            cells[nx].isAPool = false;
                        }
                    }
                    //LEFT
                    if (cells[nx].left == WallType.Level)
                    {
                        if (!this.cells[ny][nx - 1].isAPool)
                        {
                            cells[nx].isAPool = false;
                        }
                    }
                }
            }
            else
            {
                for (int nx = 0; nx < cells.Length; nx++)
                {
                    //TOP
                    if (cells[nx].top == WallType.Level)
                    {
                        if (!this.cells[ny - 1][nx].isAPool)
                        {
                            cells[nx].isAPool = false;
                        }
                    }
                    //RIGHT
                    if (cells[nx].right == WallType.Level)
                    {
                        if (!this.cells[ny][nx + 1].isAPool)
                        {
                            cells[nx].isAPool = false;
                        }
                    }
                    //BOTTOM
                    if (cells[nx].bottom == WallType.Level)
                    {
                        if (!this.cells[ny + 1][nx].isAPool)
                        {
                            cells[nx].isAPool = false;
                        }
                    }
                    //LEFT
                    if (cells[nx].left == WallType.Level)
                    {
                        if (!this.cells[ny][nx - 1].isAPool)
                        {
                            cells[nx].isAPool = false;
                        }
                    }
                }
            }
            return cells;
        }
        /// <summary>
        /// Identify all the cells that can contain water in a x-axis.
        /// </summary>
        /// <param name="cells"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private async Task<Cell[]> LineScan(Cell[] cells, ushort y)
        {
            //Scan line in x-axis.
            for (int x = 0; x < cells.Length; x++)
            {
                //Cell cannot contain water
                if (cells[x].top == WallType.Lower || cells[x].right == WallType.Lower || 
                    cells[x].bottom == WallType.Lower || cells[x].left == WallType.Lower)
                {
                    cells[x].isAPool = false;
                }
            }
            return cells;
        }
        #region Test code
        /*
        public void Print()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            for (ushort y = 0; y < cells.Length; y++)
            {
                for (ushort x = 0; x < cells[y].Length; x++)
                {
                    switch (cells[y][x].left)
                    {
                        case WallType.Level:
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            break;
                        case WallType.Higher:
                            Console.BackgroundColor = ConsoleColor.Green;
                            break;
                        case WallType.Lower:
                            Console.BackgroundColor = ConsoleColor.Red;
                            break;
                        default:
                            break;
                    }
                    Console.Write("[");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");

                    switch (cells[y][x].top)
                    {
                        case WallType.Level:
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            break;
                        case WallType.Higher:
                            Console.BackgroundColor = ConsoleColor.Green;
                            break;
                        case WallType.Lower:
                            Console.BackgroundColor = ConsoleColor.Red;
                            break;
                        default:
                            break;
                    }
                    Console.Write("^");
                    Console.BackgroundColor = ConsoleColor.Black;

                    Console.Write(" ");
                    if (cells[y][x].isAPool)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    Console.Write(cells[y][x].height);
                    Console.BackgroundColor = ConsoleColor.Black;

                    Console.Write(" ");

                    switch (cells[y][x].bottom)
                    {
                        case WallType.Level:
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            break;
                        case WallType.Higher:
                            Console.BackgroundColor = ConsoleColor.Green;
                            break;
                        case WallType.Lower:
                            Console.BackgroundColor = ConsoleColor.Red;
                            break;
                        default:
                            break;
                    }
                    Console.Write("_");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");

                    switch (cells[y][x].right)
                    {
                        case WallType.Level:
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            break;
                        case WallType.Higher:
                            Console.BackgroundColor = ConsoleColor.Green;
                            break;
                        case WallType.Lower:
                            Console.BackgroundColor = ConsoleColor.Red;
                            break;
                        default:
                            break;
                    }
                    Console.Write("]");
                    Console.BackgroundColor = ConsoleColor.Black;

                    Console.Write("   ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Pools();
        }
        public void PrintSimpel()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            for (ushort y = 0; y < cells.Length; y++)
            {
                for (ushort x = 0; x < cells[y].Length; x++)
                {
                    if (cells[y][x].isAPool)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    Console.Write(cells[y][x].height);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        */
        #endregion
        #endregion
    }
    #endregion
    #region Coordinates
    /// <summary>
    /// Defines the <see cref="Coordinates" />.<br/>
    /// Holds two coordinates of the X and Y axel.
    /// </summary>
    public class Coordinates
    {
        #region Fields
        public ushort y;
        public ushort x;
        #endregion
        #region Constructor
        public Coordinates(ushort y, ushort x)
        {
            this.y = y;
            this.x = x;
        }
        #endregion
    }
    #endregion
    #region Cell
    /// <summary>
    /// Defines the <see cref="Cell" />.<br/>
    /// A cell contains information about its neighbour's wall types, If it can collect water and how high it is. 
    /// </summary>
    public class Cell
    {
        #region Fields
        public WallType top = WallType.Higher, bottom = WallType.Higher, left = WallType.Higher, right = WallType.Higher;
        public ushort height;
        public bool isAPool = true, isAlreadyScanned = false;
        public bool isAlreadyScannedTop = false, isAlreadyScannedRight = false, isAlreadyScannedBottom = false, isAlreadyScannedLeft = false;
        #endregion
        #region Constructor
        public Cell(ushort height)
        {
            this.height = height;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Compare cell sizes against each other.
        /// </summary>
        /// <param name="firstCell"></param>
        /// <param name="compareCell"></param>
        /// <returns></returns>
        public static WallType CompareCellSize(Cell firstCell, Cell compareCell)
        {
            if (firstCell.height > compareCell.height)
                return WallType.Lower;
            else if (firstCell.height == compareCell.height)
                return WallType.Level;
            else
                return WallType.Higher;
        }

        #endregion
    }
    #endregion
}
