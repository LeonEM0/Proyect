using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Code
{
    public struct Players
    {
        
        public string Name;
        public int Score;

        public Players(string PlayerName, int PlayerScore)
        {
            Name = PlayerName;
            Score = PlayerScore;
        }
    }

    public class Game
    {
        public static char[,] activeboard = new char[3, 3];
        public static int selectindexfile = 0;
        public static int selectindexrow = 0;
        public static int loop = 0;
        public static bool gameover = false;
        public static Players[] gamers = new Players[10];
        public static int index = 0;
        
        //MAIN CODE
        public static void Main()
        {
            int option = 1;
            int games = 0;
            bool exit = false;
            
            while (exit == false)
            {
                Menu();
                option = Options();

                switch (option)
                {

                    case 1:
                        {
                            if (games < 5)
                            {
                                index = GetNicknames(index, gamers);
                                Play();
                            }
                            else
                            {
                                Console.WriteLine("MAX NUMBER OF PLAYERS REACHED");
                            }
                            index++;
                            games++;

                            EndCase();
                            break;
                        }
                    case 2:
                        {
                            ScoreBoard(gamers);
                            EndCase();
                            break;
                        }
                    case 3:
                        {

                            Console.WriteLine("-------------------------");
                            Console.WriteLine("THANK YOU FOR PLAYING!\r\n" +
                            "HOPE TO SEE YOU SOON :)");
                            exit = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("-------------------------");
                            Console.WriteLine("INVALID OPTION");
                            EndCase();
                            break;
                        }
                }

            }
        }

        // PROCEDURE FUNCTIONS
        public static void ScoreBoard(Players[] gamers)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("HIGHSCORES");
            Console.WriteLine("PLAYER\tNAME\tSCORE");
            for (int i = 0; i < gamers.Length; i++)
            {
                Console.Write(i + "\t");
                Console.Write(gamers[i].Name + "\t");
                Console.WriteLine(gamers[i].Score);
            }
        }
        public static int GetNicknames(int index, Players[] gamers)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("PLAYER NAMES\r\n");
            string name = "";
            while (string.IsNullOrEmpty(gamers[index].Name))
            {
                Console.Write("ENTER PLAYER 1 NAME: ");
                while (string.IsNullOrEmpty(name = Console.ReadLine()))
                {
                    Console.WriteLine("Invalid option value, please try again.");
                }
                if (Array.Exists(gamers, Player => Player.Name == name))
                {
                    Console.WriteLine("That name is already taken, try another one");
                }
                else
                {
                    gamers[index].Name = name;
                    break;
                }
            }   
            Console.WriteLine();
            index++;
            while (string.IsNullOrEmpty(gamers[index].Name))
            {
                Console.Write("ENTER PLAYER 2 NAME: ");
                while (string.IsNullOrEmpty(name = Console.ReadLine()))
                {
                    Console.WriteLine("Invalid option value, please try again.");
                }
                if (Array.Exists(gamers, Player => Player.Name == name))
                {
                    Console.WriteLine("That name is already taken, try another one");
                }
                else
                {
                    gamers[index].Name = name;
                    break;
                }
            }
            Console.Clear();
            return index;
        }
        public static void Play()
        {   
            bool again = true;
            int round = 1;
            int option = 1;
            while (again)
            {
                char[,] board = new char[3, 3];

                Console.WriteLine("\t\t\t*********Welcome to tic tac game*******");
                Console.WriteLine("ROUND" + round);
                
                DisplayBoardIndex();
                Console.WriteLine("Remember these numbers!");
                Console.WriteLine("\n\t\t\t\t Please introduce a O OR X in the next indexes");

                DisplayInitialBoard();

                Console.WriteLine("\n\n\t\t\t\t\t++++++The game beigns++++++\n");

                while (!gameover)
                {
                    DisplayActiveBoard(); // shows the active board  
                    DisplayBoardIndex();

                }
                round++;
                Console.WriteLine(" Want to go for round " + round + "?");
                Console.WriteLine("1 = YES :D\r\n" + "2 = NO :c");
                option = ReturnInt();
                while (option < 1 || option > 2)
                {
                    Console.WriteLine("INVALID OPTION, TRY AGAIN");
                    ReturnInt();
                }
                if (option == 2)
                {
                    again = false;
                    gameover = false;
                }
                else if (option == 1)
                {
                    gameover = false;
                    continue;
                }
                Console.Clear();
            }
        }
        
        public static void DisplayBoardIndex() // This function displays the (indexes) in the board
        {
            int[,] board = new int[3, 3];

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(0); j++)
                {
                    board[i, j] = i;  //Como asignar i y j respectivamente 

                }
            }
            DisplayIndex(board);

        }
        public static void DisplayActiveBoard()
        {

            Console.WriteLine("THE FIRST PLAYER BEGINS 'O' ");


            Console.WriteLine("Introduce in which line do you want to introduce your mark");
            selectindexfile = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduce in which row do you want to introduce your mark");
            selectindexrow = int.Parse(Console.ReadLine());


            activeboard[selectindexfile, selectindexrow] = 'O';  // POR QUE LAS FILAS Y LAS COLUMNAS ESTAN VOLTEADAS?

            verifyWinnerOne();
            verifyWinnerTwo();

            if (gameover == false)
            {
                Console.WriteLine("........");

                Console.WriteLine("THE SECOND PLAYER BEGINS");

                Console.WriteLine("Introduce in which line do you want to introduce your mark");
                selectindexfile = int.Parse(Console.ReadLine());

                Console.WriteLine("Introduce in which row do you want to introduce your mark");

                selectindexrow = int.Parse(Console.ReadLine());

                activeboard[selectindexfile, selectindexrow] = 'X';
                verifyWinnerOne();
                verifyWinnerTwo();
                Showactiveboard();
            }
            else
            {
                Showactiveboard();
                DisplayBoardIndex();
            }
        }
        public static void DisplayInitialBoard()
        {
            Console.WriteLine("\t\t\t\t\t\t _ _ _");
            for (int k = 0; k < 3; k++)
            {
                Console.Write("\t\t\t\t\t\t|");
                for (int l = 0; l < 3; l++)
                {
                    activeboard[k, l] = '?';
                    Console.Write(" " + activeboard[k, l] + " |");
                }
                Console.WriteLine("\n\t\t\t\t\t\t|_|_|_|");
            }

        }// This function display the initial board its gonna be the playable board
        public static void verifyWinnerOne()
        {
            if ((activeboard[0, 0] == 'O') && (activeboard[1, 1] == 'O') && (activeboard[2, 2] == 'O'))
            {
                

                Console.WriteLine("\t\t\t⁠++++++++++++++++++++++PLAYER ONE WINS RIGHT++++++++++++++++++++++⁠⁠");
                gameover = true;
                Console.WriteLine(gameover);

            }

            else if (activeboard[2, 0] == 'O' && activeboard[1, 1] == 'O' && activeboard[0, 2] == 'O')
            {
                Console.WriteLine("\t\t\t-------------------------PLAYER ONE WINS LEFT---------------------");
                gameover = true;
                Console.WriteLine(gameover);

            }

            for (int i = 0; i < 2; i++)
            {
                if (activeboard[0, i] == 'O' && activeboard[1, i] == 'O' && activeboard[2, i] == 'O') //3 HORIZONTAL LINES VERIFICATION
                {
                    Console.WriteLine("\t\t\t********PLAYER ONE WINSHHHH********");
                    gameover = true;
                    Console.WriteLine(gameover);

                }

                else if (activeboard[i, 0] == 'O' && activeboard[i, 1] == 'O' && activeboard[i, 2] == 'O') //3 VERTICAL LINES VERIFICATION
                {
                    Console.WriteLine("\t\t\t********PLAYER ONE WINSVVVV********");
                    gameover = true;

                    Console.WriteLine(gameover);
                }

            }
            gamers[index].Score += 1;
        }
        public static void verifyWinnerTwo()
        {


            if ((activeboard[0, 0] == 'X') && (activeboard[1, 1] == 'X') && (activeboard[2, 2] == 'X'))
            {
                Console.WriteLine("\t\t\t++++++++++++++++++++++PLAYER TWO WINS RIGHT++++++++++++++++++++++");
                gameover = true;
                Console.WriteLine(gameover);

            }

            else if (activeboard[2, 0] == 'X' && activeboard[1, 1] == 'X' && activeboard[0, 2] == 'X')
            {
                Console.WriteLine("\t\t\t-------------------------PLAYER TWO WINS LEFT---------------------");
                gameover = true;
                Console.WriteLine(gameover);

            }

            for (int i = 0; i < 2; i++)
            {
                if (activeboard[0, i] == 'X' && activeboard[1, i] == 'X' && activeboard[2, i] == 'X') //3 HORIZONTAL LINES VERIFICATION
                {
                    Console.WriteLine("\t\t\t********PLAYER TWO WINSHHHH********");
                    gameover = true;
                    Console.WriteLine(gameover);

                }

                else if (activeboard[i, 0] == 'X' && activeboard[i, 1] == 'X' && activeboard[i, 2] == 'X') //3 VERTICAL LINES VERIFICATION
                {
                    Console.WriteLine("\t\t\t********PLAYER TWO WINSVVVV********");
                    gameover = true;
                    Console.WriteLine(gameover);
                }

            }
          gamers[index].Score += 1;
        }
        public static void Showactiveboard()
        {
            Console.WriteLine("\t\t\t\t\t\t _ _ _");
            for (int k = 0; k < 3; k++)
            {

                Console.Write("\t\t\t\t\t\t|");
                for (int l = 0; l < 3; l++)
                {



                    Console.Write(" " + activeboard[k, l] + " |");


                }

                Console.WriteLine("\n\t\t\t\t\t\t|_|_|_|");




            }
        }
        public static void DisplayIndex(int[,] board)
        {
            Console.WriteLine("\t\t\t\t\t\t _ _ _");
            for (int k = 0; k < 3; k++)
            {

                Console.Write("\t\t\t\t\t\t|");
                for (int l = 0; l < 3; l++)
                {

                    Console.Write("" + board[k, l] + board[l, k] + " |");


                }
                Console.WriteLine("\n\t\t\t\t\t\t|_|_|_|");


            }
        }
       
        //QUALITY OF LIFE FUNCTIONS
        private static int ReturnInt()
        {
            int option;
            while (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Invalid option value, please try again.");
            }

            return option;
        }
        public static int Options()
        {
            int option = 0;
            while (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Invalid option value, please try again.");
            }
            Console.Clear();
            return option;
        }
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("-------------------------");
            Console.Write("WELCOME TO TIC TAC TOE!\r\n" +
                "1. START GAME\r\n" +
                "2. SHOW HIGHSCORES\r\n" +
                "3. EXIT\r\n" +
                "Enter your choice: ");
        }
        public static void EndCase()
        {
            Console.WriteLine();
            Console.Write("press ENTER to return to the menu"); Console.ReadLine();
        }

    }
}