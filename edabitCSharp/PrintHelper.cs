using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edabitCSharp
{
    public static class PrintHelper
    {
        public static string IntArrayToString(int[] inputs)
        {
            string output = "[";
            foreach (int number in inputs)
            {
                output = output + number + ", ";
            }
            output = output.Remove(output.Length - 2);
            output = output + "]";
            return output;
        }
    }
}
