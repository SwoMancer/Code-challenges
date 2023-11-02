using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edabitCSharp
{
    public enum ChallengeLevel{ Very_Easy, Easy, Medium, Hard, Very_Hard, Expert }
    public abstract class Challenge
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string UserInputTestExplanation { get; set; }
        public ChallengeLevel Level { get; set; }
        public abstract void BlindTest();
        public abstract void UserInputTest(string input);
        public override string ToString()
        {
            return Name + "\n" + Description + "\n\n" + Link + "\n\n" + Level.ToString();
        }
    }
}
