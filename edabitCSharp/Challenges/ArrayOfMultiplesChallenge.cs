using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edabitCSharp.Challenges
{
    public class ArrayOfMultiplesChallenge : Challenge
    {
        public ArrayOfMultiplesChallenge() 
        { 
            this.Name = "Array Of Multiples";
            this.Description = "Create a function that takes two numbers as arguments (num, length) and returns an array of multiples of num until the array length reaches length.";
            this.UserInputTestExplanation = "input num, length.";
            this.Level = ChallengeLevel.Medium;
            this.Link = "https://edabit.com/challenge/2QvnWexKoLfcJkSsc";
        }
        public override void BlindTest()
        {
            Random random = new Random();
            int num = random.Next(1, 100);
            int length = random.Next(1, 100);
            Console.WriteLine("num: " + num + ", length: " + length);
            Console.WriteLine(PrintHelper.IntArrayToString(GenerateOutput(num, length)));
        }

        public override void UserInputTest(string input)
        {
            string[] inputCuts = input.Split(' ');
            int num = int.Parse(inputCuts[0]);
            int length = int.Parse(inputCuts[1]);

            Console.WriteLine(PrintHelper.IntArrayToString(GenerateOutput(num, length)));
        }
        private int[] GenerateOutput(int num, int length) 
        {
            int[] output = new int[length];

            for (int i = 0; i < length; i++)
                output[i] = (i + 1) * num;

            return output;
        }
    }
}
