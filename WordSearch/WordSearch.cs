using System;
using System.IO;
using System.Linq;

namespace WordSearch
{
    enum Directions
    {
        HorizontalLeftRight,
        HorizontalRightLeft,
        VerticalTopDown,
        VerticalDownTop,
        DiagonalDownForward,
        DiagonalUpForward,
        DiagonalDownBackward,
        DiagonalUpBackward,
    }

    internal class WordSearch
    {
        static Random random = new Random();

        static string[][] grid = new string[21][];
        static string[] categories;
        static string[] words;
        static string playerInput = "";
        static string brand = "";
        static string rowInput;
        static string colInput;

        static bool stop;
        static bool isPlaying = true;
        static bool coordinatesCheck = false;

        static int playerInputInt = 0;
        static int startRow;
        static int startCol;
        static int RowOffset;
        static int ColOffset;
        static int newRow;
        static int newCol;
        static int rowInputInt;
        static int colInputInt;
        static int nOfCheckedWords;

        private static Dictionary<string, int[]> wordPositions = new Dictionary<string, int[]>();
        static void Main(string[] args)
        {

            TextFileGenerator.MakeFile();
            string wordsFilePath = "words.txt";
            string allCategoriesAndWords = File.ReadAllText(wordsFilePath);

            Console.WriteLine("Select one of this categories \n");
            GetCategories();


            stop = false;

            //player game inputs
            while (!stop)
            {
                playerInput = Console.ReadLine();

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

            InitializeGrid();
            InsertWordsInGrid();
            DisplayGrid();

            do //main gameplay loop
            {
                stop = true;
                do //player word input loop
                {

                    Console.WriteLine("\n Which word are you looking for? \n");
                    playerInput = Console.ReadLine();

                    foreach (string word in words)
                    {
                        if (playerInput == word)
                        {
                            stop = false;
                            break;
                        }
                    }
                    if (stop)
                    {
                        Console.WriteLine("input is not in the list of models, try again: \n");
                    }

                } while (stop);

                AskCoordinates();
                CheckCoordinates(playerInput);


                if (coordinatesCheck)//keep playing
                {
                    Console.WriteLine("Word found! \n");
                    nOfCheckedWords++;
                    if (nOfCheckedWords == 8)
                    {
                        isPlaying = false;
                    }
                    DisplayGrid(); 
                }
                else if (!coordinatesCheck)//wrong word/wrong input
                {
                    Console.WriteLine("Word not found! \n");
                }

            } while (isPlaying);

        }

        private static void GetCategories()
        {

            categories = TextFileGenerator.wordsDictionary.Keys.ToArray();
            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine(i + " " + categories[i] + "\n");
            }
        }

        private static void GetWords(string brandInput)
        {
            if (TextFileGenerator.wordsDictionary.TryGetValue(brandInput, out string[] models))
            {
                brand = brandInput;
                words = models.OrderBy(x => random.Next()).Take(8).ToArray();
            }
        }

        private static void InitializeGrid()
        {
            for (int i = 0; i < grid.Length; i++)
            {
                grid[i] = new string[grid.Length];
            }

            grid[0][0] = "0";

            for (int i = 1; i < grid.Length; i++)
            {
                grid[0][i] = i.ToString();
                grid[i][0] = i.ToString();
            }


            for (int row = 1; row < grid.Length; row++)
            {
                for (int col = 1; col < grid.Length; col++)
                {
                    grid[row][col] = ((char)('A' + random.Next(0, 26))).ToString();
                }
            }
        }

        private static void InsertWordsInGrid()
        {
            foreach (string currentWord in words)
            {
                bool inserted = false;
                while (!inserted)
                {
                    bool canPlace = true;
                    startRow = random.Next(grid.Length);
                    startCol = random.Next(grid.Length);

                    Array DirectionValues = Enum.GetValues(typeof(Directions));
                    Directions dir = (Directions)random.Next(DirectionValues.Length);

                    switch (dir)
                    {
                        case Directions.HorizontalLeftRight:
                            RowOffset = 0;
                            ColOffset = 1;
                            break;
                        case Directions.HorizontalRightLeft:
                            RowOffset = 0;
                            ColOffset = -1;
                            break;
                        case Directions.VerticalTopDown:
                            RowOffset = 1;
                            ColOffset = 0;
                            break;
                        case Directions.VerticalDownTop:
                            RowOffset = -1;
                            ColOffset = 0;
                            break;
                        case Directions.DiagonalUpForward:
                            RowOffset = -1;
                            ColOffset = 1;
                            break;
                        case Directions.DiagonalUpBackward:
                            RowOffset = -1;
                            ColOffset = -1;
                            break;
                        case Directions.DiagonalDownForward:
                            RowOffset = 1;
                            ColOffset = 1;
                            break;
                        case Directions.DiagonalDownBackward:
                            RowOffset = 1;
                            ColOffset = -1;
                            break;
                        default:
                            RowOffset = 0;
                            ColOffset = 0;
                            break;
                    }

                    // Check if word fits
                    for (int i = 0; i < currentWord.Length; i++)
                    {
                        int newRow = startRow + i * RowOffset;
                        int newCol = startCol + i * ColOffset;

                        if (newRow < 1 || newRow >= grid.Length || newCol < 1 || newCol >= grid[newRow].Length)
                        {
                            canPlace = false;
                            break;
                        }
                    }

                    if (canPlace)
                    {
                        for (int i = 0; i < currentWord.Length; i++)
                        {
                            int newRow = startRow + i * RowOffset;
                            int newCol = startCol + i * ColOffset;
                            grid[newRow][newCol] = currentWord[i].ToString().ToLower();
                        }

                        wordPositions[currentWord] = new int[] { startRow, startCol, RowOffset, ColOffset };

                        inserted = true;
                    }
                }
            }
        }

        private static void DisplayGrid()
        {
            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid.Length; col++)
                {
                    Console.Write(grid[row][col].PadRight(3));
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n" + "Selected models for " + brand);
            foreach (string model in words)
            {
                Console.WriteLine(model);
            }
        }

        private static void AskCoordinates()
        {
            Console.WriteLine("Insert row of your word: ");

            stop = false;
            while (!stop)
            {
                rowInput = Console.ReadLine();

                if (Int32.TryParse(rowInput, out rowInputInt))
                {
                    if (rowInputInt < 1 || rowInputInt > 20)
                    {
                        Console.WriteLine("Input out of bounds, select a number between 1 and 20: ");
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

            Console.WriteLine("Insert column of your word: ");

            stop = false;
            while (!stop)
            {
                colInput = Console.ReadLine();

                if (Int32.TryParse(colInput, out colInputInt))
                {
                    if (colInputInt < 1 || colInputInt > 20)
                    {
                        Console.WriteLine("Input out of bounds, select a number between 1 and 20: ");
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

        }

        private static void CheckCoordinates(string currentWord)
        {
            Console.WriteLine("Checking word: " + currentWord);
            coordinatesCheck = false;

            int[] position = wordPositions[currentWord];
            int startRow = position[0];
            int startCol = position[1];
            int rowOffset = position[2];
            int colOffset = position[3];

            for (int i = 0; i < currentWord.Length; i++)
            {
                int newRow = startRow + i * rowOffset;
                int newCol = startCol + i * colOffset;

                if (grid[newRow][newCol] == currentWord[i].ToString().ToLower())
                {
                    coordinatesCheck = true;
                    grid[newRow][newCol] = "";
                }
                else
                {
                    return;
                }
            }
        }
    }
}
