using System;
using System.Collections.Generic;

namespace PeanutFactory
{
    #region Program
    public class Program
    {
        #region Methods
        public static void Main(string[] args)
        {
            string line;
            List<string> outputs = new List<string>();
            //Keep reading data until it becomes 0.
            while ((line = Console.ReadLine()) != "0")
            {
                outputs.AddRange(InspectBatch(byte.Parse(line.Trim())));
            }

            //print outout...
            foreach (string output in outputs)
                Console.WriteLine(output);
        }
        /// <summary>
        /// Read inputs and create boxes and peanuts.
        /// </summary>
        /// <param name="boxQuantity"></param>
        /// <returns></returns>
        private static List<string> InspectBatch(byte boxQuantity)
        {
            PackingCase packingCase = new PackingCase();

            //Loop box quantity
            for (byte i = 0; i <= boxQuantity - 1; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ', StringSplitOptions.TrimEntries);

                packingCase.boxes.Add(new Box(float.Parse(inputs[0], System.Globalization.CultureInfo.InvariantCulture),
                    float.Parse(inputs[1], System.Globalization.CultureInfo.InvariantCulture),
                    float.Parse(inputs[2], System.Globalization.CultureInfo.InvariantCulture),
                    float.Parse(inputs[3], System.Globalization.CultureInfo.InvariantCulture),
                    inputs[4]));
            }

            string line = Console.ReadLine().Trim();

            //If there are no peanuts to inspect...
            if (line == "0")
            {
                //End case
                Console.WriteLine();
                List<string> outputs = new List<string>();
                outputs.Add("");
                return outputs;
            }

            //Loop peanut quantity
            ushort peanutQuantity = ushort.Parse(line.Trim());
            for (ushort i = 0; i <= peanutQuantity - 1; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ', StringSplitOptions.TrimEntries);
                packingCase.peanuts.Add(new Peanut(float.Parse(inputs[0], System.Globalization.CultureInfo.InvariantCulture),
                    float.Parse(inputs[1], System.Globalization.CultureInfo.InvariantCulture),
                    inputs[2]));
            }

            return packingCase.InspectPeanuts();
        }
        #endregion
    }

    #endregion
}
