using System;
using System.Text;


namespace GuessTheCode
{
    class Program
    {
       
        static void Main(string[] args)
        {
            string[] LockCodes = new string[4];
            var rand = new Random();
            for (int i = 0; i < LockCodes.Length; i++)
            {
                LockCodes[i] = rand.Next(1, 6).ToString();
            }

            string LockCode = string.Join("", LockCodes);
            Console.WriteLine("Welcome! Please guess the 4 digit code: ");
            string guess;
            int guessCount = 0;
            string guessResultFinal = "Sorry you are out of guesses.";

            do
            {
                guessCount++;
                guess = Console.ReadLine();
                int num;
                string guessResult = ""; 
                if (int.TryParse(guess, out num) && guess.Length == 4)
                {
                    Console.WriteLine("Try {0}", guessCount);
                    Console.WriteLine("{0} Guess", guess);
                    for (int i = 0; i < guess.Length; i++)
                    {
                        if (string.Join("", LockCodes).IndexOf(guess.Substring(i,1)) != -1)
                        {
                            if (guess.Substring(i, 1) == LockCode.Substring(i, 1))
                            {
                                guessResult = guessResult + "+";
                            }
                            else {
                                guessResult = guessResult + "-";
                            }
                        }
                        else
                        {
                            guessResult = guessResult + " ";
                        }
                    }
                    
                    Console.WriteLine("{0} Result", guessResult);
                    if (guessResult == "++++")
                    {
                        guessResultFinal = "*** Horray you won! ***";
                        guessCount = 10;
                    }
                }
                else {
                    Console.WriteLine("Invalid entry.");
                }
            } while (guess != null && guessCount < 10);

            Console.WriteLine(guessResultFinal);
            Console.WriteLine("Press any key to exit.");

            Console.ReadLine();
        }
    }
}
