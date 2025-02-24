using System;
using System.IO;
using System.Linq;

namespace WordSearch
{

    internal class WordSearch
    {
        static string[][] grid = new string[21][]; 
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

            InitializeGrid();
            DisplayGrid();

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
                    GetWords("Kawasaki");
                    break;
                    case 6:
                    GetWords("BMW");
                    break;
                    case 7:
                    GetWords("Lamborghini");
                    break;
                    case 8:
                    GetWords("Honda");
                    break;
                    case 9:
                    GetWords("Porsche");
                    break;
            }

        }

       
        private static void GetCategories()
        {
           
            categories = TextFileGenerator.wordsDictionary.Keys.ToArray();
            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine(i + " " + categories[i] + "\n");
            }
        }

        private static void GetWords(string brand)
        {
            if (TextFileGenerator.wordsDictionary.TryGetValue(brand, out string[] models))
            {
                    string[] selectedModels = models.OrderBy(x => random.Next()).Take(8).ToArray();

                    Console.WriteLine("Selected models for " + brand);
                    foreach (var model in selectedModels)
                    {
                        Console.WriteLine(model);
                    }
            }
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

            foreach (var word in words)
            {
                bool placed = false;
                while (!placed)
                {
                    int row = random.Next(20);
                    int col = random.Next(20);
                    int direction = random.Next(3); // 0: horizontal, 1: vertical, 2: diagonal

                    if (CanPlaceWord(grid, word, row, col, direction))
                    {
                        PlaceWord(grid, word, row, col, direction);
                        placed = true;
                    }
                }
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
