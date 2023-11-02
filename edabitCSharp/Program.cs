namespace edabitCSharp
{
    public class Program
    {
        private static List<Challenge> _challenges;
        public static void Main(string[] args)
        {
            LoadAllChallenges();
            ChooseChallenge();
        }

        private static void ChooseChallenge()
        {
            bool chooseChallengeLoop = true;
            bool userWantsToQuit = false;
            int challengeInput = 0;

            while (chooseChallengeLoop)
            {
                Console.Clear();
                PrintChallenges();
                Console.WriteLine("Write the number of the challenge to select it.");
                Console.Write("Challenge number: ");
                try
                {
                    challengeInput = int.Parse(Console.ReadLine().Trim());

                    if (challengeInput == 0)
                    {
                        chooseChallengeLoop = false;
                    }
                    else
                    {
                        Console.WriteLine(_challenges[challengeInput - 1].ToString());
                        Console.WriteLine();
                        ChooseAlternative(challengeInput);
                    }
                }
                catch
                {
                    Console.WriteLine("Select an available number.");
                    Console.ReadKey();
                }
            }

            
        }

        private static void ChooseAlternative(int challengeInput)
        {
            bool chooseChallengeAlternativeLoop = true;
            while (chooseChallengeAlternativeLoop)
            {
                Console.Clear();
                Console.WriteLine("\t[1] [Random test without input]");
                Console.WriteLine("\t[2] [Test with input]");
                Console.WriteLine("\t[3] [Go back to challenge list]");
                Console.WriteLine();

                Console.WriteLine("Write the number of the alternative to select it.");
                Console.Write("alternative number: ");
                int alternativeInput = 0;
                try
                {
                    alternativeInput = int.Parse(Console.ReadLine().Trim());
                }
                catch
                {
                    alternativeInput = 0;
                }

                switch (alternativeInput)
                {
                    case 1:
                        _challenges[challengeInput - 1].BlindTest();
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Type: ");
                        Console.WriteLine(_challenges[challengeInput - 1].UserInputTestExplanation);
                        Console.Write("Input: ");
                        _challenges[challengeInput - 1].UserInputTest(Console.ReadLine().Trim());
                        Console.ReadKey();
                        break;
                    case 3:
                        chooseChallengeAlternativeLoop = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private static void PrintChallenges()
        {
            Console.Clear();
            Console.WriteLine("Quantity: " + _challenges.Count);

            Console.WriteLine("\t" + 0 + " [" + "Exit" + "]");

            int i = 1;
            foreach (Challenge challenge in _challenges)
                Console.WriteLine("\t" + i++ + " [" + challenge.Name + "]");

            Console.WriteLine();
        }

        private static void LoadAllChallenges()
        {
            _challenges = new List<Challenge>
            {
                new Challenges.ArrayOfMultiplesChallenge(),
                new Challenges.AreaOfATrianglChallenge(),
                new Challenges.FindTheBombChallenge()
            };
        }
    }
}