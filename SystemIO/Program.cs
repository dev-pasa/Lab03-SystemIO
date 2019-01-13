using System;
using System.IO;

namespace SystemIO

{
    class Program
    {
        static void Main(string[] args)
        {
            // Vinicio - we are relying on the intenal structure of the project
            string path = "../../../testFile.txt";
            string[] startWords = { "josie", "kitty", "oscar", "molly", "coco" };
            CreateFile(path, startWords);
            //CreateFile(path);

            //ReadFile(path);
            //AppendToFile(path);
            //DeleteFile(path);
            //PlayingWithSplit();
            GameView(path);
        }

        static void GameView(string path)
        {
            Console.WriteLine("Hello! Welcome to the guessing game.");
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

        static void CreateFile(string path, string[] passWords)
        {
            // Using statement (finally ALL IN ONE)
            try
            {
                // Vinicio - the using is only making sure that you closer your file
                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    // Vinicio - as soon as I leave this block. THe engine will dispose
                    // streamWriter

                    //Console.WriteLine("Gregor is the very best");
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

        public static void GameStart(string path)
        {
            Console.WriteLine("Let's start the game!");
            Console.WriteLine("Guess the characters of the word.");

            string[] words = ReadWords(path);

            //select random word from the list

            Random random = new Random();
            int randomIndx = random.Next(words.Length);

            string solutionWord = words[randomIndx];
            string[] gussedChar = new string[solutionWord.Length];

            for (int i = 0; i < gussedChar.Length; i++)
            {
                gussedChar[i] = " _ ";
            }

            foreach (string hiddenChar in gussedChar)
            {
                Console.Write(hiddenChar);

            }
            //Console.WriteLine();
            //based on the the number of letter output same number of _ _ _




            //if the user gets the letter correct replace _ with char










        }

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