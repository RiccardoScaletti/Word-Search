using System;
using System.IO;
using System.Linq;

namespace WordSearch
{
    using System;
    using System.IO;

    internal class WordSearch
    {
        static string[][] grid = new string[21][]; // 21x21 Grid
        static Random random = new Random();
        static string[] categories;
        static string[] words;
        static bool stop;
        static string playerInput = "";
        static int playerInputInt = 0;

        static void Main(string[] args)
        {

            TextFileGenerator.MakeFile();
            string wordsFilePath = "words.txt";
            string allCategoriesAndWords = File.ReadAllText(wordsFilePath);

            Console.WriteLine("Select one of this categories \n");
            GetCategories();

            
            stop = false;

            while (!stop)
            {
                playerInput = Console.ReadLine();
                playerInputInt = 0;

                if (Int32.TryParse(playerInput, out playerInputInt))
                {
                    if (playerInputInt < 0 || playerInputInt > 9)
                    {
                        Console.WriteLine("Input out of bounds, select a number between 0 and 9: ");
                    }
                    else
                    {
                       stop = true;
                       break; 
                    }
                }
                else
                {
                    if (!stop)
                    {
                        Console.WriteLine("Wrong input, try again: ");
                    }
                }
            }

            switch (playerInputInt)
            {
                    case 0:
                    GetWords("Ducati");
                    break;
                     case 1:
                    GetWords("Ferrari");
                    break;
                    case 2:
                    GetWords("Yamaha");
                    break;
                    case 3:
                    GetWords("Suzuki");
                    break;
                    case 4:
                    GetWords("Nissan");
                    break;
                    case 5:
                    break;
                    case 6:
                    break;
                    case 7:
                    break;
                    case 8:
                    break;
                    case 9:
                    break;
            }

            InitializeGrid();
            DisplayGrid();
        }

       
        private static void GetCategories()
        {
           
            categories = TextFileGenerator.wordsDictionary.Keys.ToArray();
            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine(i + " " + categories[i] + "\n");
            }
        }

        private static void GetWords(string cat)
        {
            words = TextFileGenerator.wordsDictionary[cat];
            string[] selectedWords = new string[7];
            while (selectedWords[7] == null)
            {
                int index = random.Next(words.Length);// Random index from 0 to 14
                selectedWords[index] = (words[index]);
                
            }
            foreach (string word in selectedWords) { Console.WriteLine(word); }
        }



        private static void InitializeGrid()
        {
            for (int i = 0; i < 21; i++)
            {
                grid[i] = new string[21]; // Initialize each row
            }

            grid[0][0] = " "; // Empty corner

            for (int i = 1; i < 21; i++)
            {
                grid[0][i] = i.ToString(); 
                grid[i][0] = i.ToString();
            }

            for (int row = 1; row < 21; row++)
            {
                for (int col = 1; col < 21; col++)
                {
                    grid[row][col] = ((char)('A' + random.Next(0, 26))).ToString(); // Random letter A-Z
                }
            }
        }

        private static void DisplayGrid()
        {
            for (int row = 0; row < 21; row++)
            {
                for (int col = 0; col < 21; col++)
                {
                    Console.Write(grid[row][col].PadRight(3));
                }
                Console.WriteLine();
            }
        }
    }
}
