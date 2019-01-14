using System;
using System.IO;
using System.Linq;

namespace SystemIO

{
    public class Program
    {
        static void Main(string[] args)
        {
            // Vinicio - we are relying on the intenal structure of the project
            string path = "../../../testFile.txt";
            string[] startWords = { "josie", "kitty", "oscar", "molly", "coco" , "charlie", "bella", "lucy"};
            CreateFile(path, startWords);
            //CreateFile(path);

            //ReadFile(path);
            //AppendToFile(path);
            //DeleteFile(path);
            //PlayingWithSplit();
            GameView(path);
        }

        /// <summary>
        /// method that calls the game
        /// </summary>
        /// <param name="path"></param>
        static void GameView(string path)
        {
            Console.WriteLine("Hello! Welcome to the guessing game.");
            Console.WriteLine("You will have to guess a word. The word is a name of a cat.");
            Console.WriteLine("You can also add a word in the saved list if you want.");
            Console.WriteLine();
            Console.WriteLine("Make a selection from the options below to begin");
            Console.WriteLine(" 1 -- Play Game");
            Console.WriteLine(" 2 -- Edit Game");
            Console.WriteLine(" 3 -- Exit");
            int userSelection = Int32.Parse(Console.ReadLine());

            switch (userSelection)
            {
                case 1:
                    GameStart(path);
                    break;
                case 2:
                    Console.Clear();
                    MakeChanges(path);
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    break;

            }
        }

        /// <summary>
        /// Add words to the game, stored in testFile
        /// </summary>
        /// <param name="path"></param>
        public static void MakeChanges(string path)
        {

            bool EditMenu = false;
            while (!EditMenu)
            {
                Console.WriteLine("Do you want to make changes in the game?");
                Console.WriteLine("Please select from the following options");
                Console.WriteLine(" 1 -- View Words");
                Console.WriteLine(" 2 -- Add Word");
                Console.WriteLine(" 3 -- Remove");
                Console.WriteLine(" 4 -- Return Home");
                int userSelection = Int32.Parse(Console.ReadLine());

                switch (userSelection)
                {
                    case 1:
                        foreach (string word in ReadWords(path))
                        {
                            Console.WriteLine(word);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Type in the word you'd like to add to the list: ");
                        string userAdd = Console.ReadLine();
                        WordAdd(path, userAdd);
                        break;
                    case 3:
                        Console.WriteLine("Enter the word you'd live to remove from the game: ");
                        string userRemove = Console.ReadLine();
                        WordRemove(path, userRemove);
                        break;
                    case 4:
                        Console.Clear();
                        GameView(path);
                        break;
                    default:
                        Console.Clear();
                        break;

                }

            }

        }

        /// <summary>
        /// This method creates a file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="passWords"></param>
        public static void CreateFile(string path, string[] passWords)
        {
            // Using statement (finally ALL IN ONE)
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    
                    try
                    {
                        foreach (string word in passWords)
                        {
                            streamWriter.WriteLine(word);
                        }

                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            catch (IOException e)
            {

                Console.Write(e);
                throw;
            }
            catch (NotSupportedException e)
            {

                Console.Write(e);
                throw;
            }
            catch (Exception e)
            {

                Console.Write(e);
                throw;
            }
            //try
            //{
            //    // CREATE FILE 

            //}
            //catch (Exception e)
            //{
            //    // HANDLE ERRORS
            //}
            //finally
            //{
            //    // DISPOSE FILE
            //}

        }

        /// <summary>
        /// This is to start the game
        /// </summary>
        /// <param name="path"></param>
        public static void GameStart(string path)
        {
            //select random word from the list
            Random random = new Random();
            string[] words = ReadWords(path);
            int randomIndx = random.Next(words.Length);

            string gameWord = words[randomIndx];

            string[] hiddenCharacters = new string[gameWord.Length];

            //replace the hidden string with  " _ ", the length of hidden word is equal to the length of the solution word
            for (int i = 0; i < hiddenCharacters.Length; i++)
            {
                hiddenCharacters[i] = " _ ";
            }

            for (int i = 0; i < hiddenCharacters.Length; i++)
            {
                Console.Write(hiddenCharacters[i]);
            }

            Console.WriteLine();
            bool gameWin = false;
            string guessedLetter = "";

            while (!gameWin)
            {
                Console.WriteLine("Guess the hidden letter, one letter at a time.");
                string inputLetter = Console.ReadLine();

                guessedLetter += inputLetter;
          
                for (int i = 0; i < hiddenCharacters.Length; i++)
                {
                    if (string.Equals(hiddenCharacters[i], inputLetter, StringComparison.CurrentCultureIgnoreCase))
                    {
                        hiddenCharacters[i] = inputLetter;
                    }
                }

                if (gameWord.Contains(inputLetter))
                {
                    for (int i = 0; i < gameWord.Length; i++)
                    {
                        if (gameWord[i].ToString() == inputLetter)
                        {
                            hiddenCharacters[i] = inputLetter;
                        }
                    }
                }
                //replace the
                Console.WriteLine($"These are your guesses so far: {guessedLetter}");
                foreach (string character in hiddenCharacters)
                {
                    Console.Write(character);
                }
                Console.WriteLine();

                if (!hiddenCharacters.Contains(" _ "))
                {
                    Console.WriteLine("Well done, you got it!");
                    gameWin = true;    
                }
            }
        }

        /// <summary>
        /// this is to add word in the test file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="newWord"></param>
        public static void WordAdd(string path, string newWord)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(newWord);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// To remove word from the test file. However, when the game is run, the initial words will be added
        /// </summary>
        /// <param name="path"></param>
        /// <param name="wordToRemove"></param>
        public static void WordRemove(string path, string wordToRemove)
        {
            try
            {
                string[] words = ReadWords(path);
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i] == wordToRemove)
                    {
                        words[i] = null;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// read teh words
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[] ReadWords(string path)
        {
            try
            {
                string[] Words = File.ReadAllLines(path);
                return Words;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// read the file
        /// </summary>
        /// <param name="path"></param>
        public static void ReadFile(string path)
        {
            try
            {
                string[] lines = File.ReadAllLines(path);
                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine(lines[i]);
                }

                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// append words to the file when called
        /// </summary>
        /// <param name="path"></param>
        /// <param name="newWord"></param>
        static void AppendToFile(string path, string newWord)
        {
            try
            {
                using (StreamWriter streamWriter = File.AppendText(path))
                {
                    streamWriter.WriteLine(newWord);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// deletes the file
        /// </summary>
        /// <param name="path"></param>
        static void DeleteFile(string path)
        {
            try
            {
                File.Delete(path);

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// not sure what it does
        /// </summary>
        static void PlayingWithSplit()
        {
            char[] delimiterCharacters = { ' ', ',', '.', ':', '\t' };
            string textToSplit = "one\ttwo three,four:five";
            string[] words = textToSplit.Split(delimiterCharacters);
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}