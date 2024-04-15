namespace Cow_Bull
{
    internal class Program
    {
        static string word = "";
        /// <summary>
        /// Get the word from the user
        /// </summary>
        /// <returns> string </returns>
        static string GetOriginalWord()
        {
            Console.WriteLine("Enter the word to be guessed : ");
            return  Console.ReadLine();
        }
        /// <summary>
        /// Start the Game
        /// </summary>
        public void StartGame()
        {
            word = GetOriginalWord();   
            
            int cows = 0;
            int bulls = 0;

            
            Console.WriteLine("Try to guess the 4-letter word.");

            while (true)
            {
                Console.Write("Enter your guess: ");
                string guess = Console.ReadLine();

                if (guess.Length == 0 || guess.Length != 4)
                {
                    Console.WriteLine("Please enter a 4-letter word.");
                    continue;
                }

                cows = 0;
                bulls = 0;

                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == guess[i])
                    {
                        cows++;
                    }
                    else if (word.Contains(guess[i]))
                    {
                        bulls++;
                    }
                }

                Console.WriteLine($"cows - {cows}, bulls - {bulls}");

                if (cows == 4)
                {
                    Console.WriteLine("Congrats!! you won the game!!");
                    break;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Cow and Bull game!");
            Program cowbull = new Program();
            cowbull.StartGame();
        }
    }

}
