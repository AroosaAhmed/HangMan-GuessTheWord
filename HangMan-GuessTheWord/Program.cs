using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan_GuessTheWord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<char> c = new List<char>() { 'd','b'};
            Console.WriteLine("Welcome in the Game! :)");
            Console.WriteLine("\n ===================================================================");
            Random random = new Random();
            List<string> randomWords = new List<string>() {"flower", "input", "to", "hello", "huge", "for", "happilly", "meeting", "null", "beautiful" };
            int numberOfRightGuesses = 0;
            int numberOfWrongGuesses = 0;
            bool won = false;
            int index = random.Next(randomWords.Count);
            string randomlyGeneratedWord = randomWords[index];
            foreach(char word in randomlyGeneratedWord)
            {
                Console.Write("_  ");
            }
            List<char> guessesList = new List<char>();
            while(numberOfWrongGuesses < 6 && numberOfRightGuesses != randomlyGeneratedWord.Length)
            {
                Console.Write("\n\nAll the guesses so far: ");
                foreach(char g in guessesList)
                {
                    Console.Write(" " + g + " ");
                }
                Console.Write("\nEnter your next guess: ");
                char guess = Console.ReadLine()[0];
                if(guessesList.Contains(guess))
                {
                    Console.WriteLine("\nYou have already entered this Character");
                    showHangMan(numberOfWrongGuesses);
                    numberOfRightGuesses = compareAndPrint(guessesList, randomlyGeneratedWord);
                    printLines(randomlyGeneratedWord);
                }
                else
                {
                    bool exist = false;
                    for(int i = 0; i < randomlyGeneratedWord.Length; i++)
                    {
                        if (randomlyGeneratedWord[i] == guess)
                        {
                            exist = true;
                        }
                    }
                    if (exist)
                    {
                        showHangMan(numberOfWrongGuesses);
                        guessesList.Add(guess);
                        numberOfRightGuesses = compareAndPrint(guessesList, randomlyGeneratedWord);
                        printLines(randomlyGeneratedWord);
                        won = true;
                    }
                    else
                    {
                        numberOfWrongGuesses++;
                        guessesList.Add(guess);
                        showHangMan(numberOfWrongGuesses);
                        numberOfRightGuesses = compareAndPrint(guessesList, randomlyGeneratedWord);
                        printLines(randomlyGeneratedWord);
                        won = false;
                    }
                }
            }
            if(won)
                Console.WriteLine("\nThank you for playing! You won the game :)");
            else
                Console.WriteLine("\nThank you for playing! Game is over :)");

            //int r = compareAndPrint(c, "random");
            //printLines("random");
            //Console.WriteLine(r);
            Console.ReadLine();

        }
        public static void printLines(string randomlyGeneratedWord)
        {
            Console.WriteLine("\r");
            foreach(char c in randomlyGeneratedWord)
            {
                Console.OutputEncoding = Encoding.Unicode;
                Console.Write(" \u0305 ");
            }
        }
        public static int compareAndPrint(List<char>userGuessedCharacters, String randomlyGeneratedWord)
        {
            int counter = 0;
            int numberOfRightInput = 0;
            foreach(char character in randomlyGeneratedWord)
            {
                if(userGuessedCharacters.Contains(character))
                {
                    Console.Write(character + " ");
                    numberOfRightInput++;
                }
                else
                {
                    Console.Write(" ");

                }
                counter++;
            }
            return numberOfRightInput;
        }
        public static void showHangMan(int numberOfTimesWrongInput)
        {
            switch (numberOfTimesWrongInput)
            {
                case 1:

                    Console.WriteLine("+----+");
                    Console.WriteLine("0    |");
                    Console.WriteLine("     |");
                    Console.WriteLine("     |");
                    Console.WriteLine("   -----");
                    break;
                case 2:
                    Console.WriteLine("+----+");
                    Console.WriteLine("0    |");
                    Console.WriteLine("|    |");
                    Console.WriteLine("     |");
                    Console.WriteLine("   -----");
                    break;
                case 3:
                    Console.WriteLine("+----+");
                    Console.WriteLine(" 0    |");
                    Console.WriteLine("/|    |");
                    Console.WriteLine("      |");
                    Console.WriteLine("    -----");
                    break;
                case 4:
                    Console.WriteLine("+----+");
                    Console.WriteLine(" 0    |");
                    Console.WriteLine("/|\\   |");
                    Console.WriteLine("      |");
                    Console.WriteLine("    -----");
                    break;
                case 5:
                    Console.WriteLine("+----+");
                    Console.WriteLine(" 0    |");
                    Console.WriteLine("/|\\   |");
                    Console.WriteLine("/     |");
                    Console.WriteLine("    -----");
                    break;
                case 6:
                    Console.WriteLine("+----+");
                    Console.WriteLine(" 0    |");
                    Console.WriteLine("/|\\   |");
                    Console.WriteLine("/ \\   |");
                    Console.WriteLine("    -----");
                    break;
            }
        }
    }
}
