using Microsoft.VisualBasic;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TrappingRainWater
{
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
}
