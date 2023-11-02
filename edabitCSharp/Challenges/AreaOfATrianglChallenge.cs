using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edabitCSharp.Challenges
{
    public class AreaOfATrianglChallenge : Challenge
    {
        public AreaOfATrianglChallenge() 
        {
            this.Name = "Area of a Triangle";
            this.Description = "Write a function that takes the base and height of a triangle and return its area.";
            this.UserInputTestExplanation = "input num, num.";
            this.Level = ChallengeLevel.Very_Easy;
            this.Link = "https://edabit.com/challenge/aiaLK9Tg6qc8sLDjv";
        }
        public override void BlindTest()
        {
            Random random = new Random();
            int baseNumber = random.Next(1, 10000);
            int heightNumber = random.Next(1, 10000);
            Console.WriteLine("base:" + baseNumber + ", height: " + heightNumber);
            Console.Write(GenerateOutput(baseNumber, heightNumber));
        }

        private int GenerateOutput(int baseNumber, int heightNumber)
        {
            return (baseNumber * heightNumber) / 2;
        }

        public override void UserInputTest(string input)
        {
            try
            {
                string[] inputCuts = input.Split(' ');
                int baseNumber = int.Parse(inputCuts[0]);
                int heightNumber = int.Parse(inputCuts[1]);

                Console.Write(GenerateOutput(baseNumber, heightNumber));
            }
            catch
            {
                Console.Write("Bad input data, try again.");
            }
        }
    }
}
