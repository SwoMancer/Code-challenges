using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edabitCSharp.Challenges
{
    public class FindTheBombChallenge : Challenge
    {
        public FindTheBombChallenge() 
        {
            this.Name = "Find the Bomb";
            this.Description = "Create a function that finds the word \"bomb\" in the given string (not case sensitive). If found, return \"Duck!!!\", otherwise, return \"There is no bomb, relax.\".";
            this.UserInputTestExplanation = "input string";
            this.Level = ChallengeLevel.Medium;
            this.Link = "https://edabit.com/challenge/JYEufqRvkusjr5R58";
        }
        public override void BlindTest()
        {
            Console.WriteLine("no random text generator is available to test with.");
        }

        public override void UserInputTest(string input)
        {
            if (input.Trim().ToLower().Contains("bomb"))
            {
                Console.WriteLine("Duck!!!");
            }
            else 
            {
                Console.WriteLine("There is no bomb, relax.");
            }
        }
    }
}
