using System;

namespace Code
{
    public struct Players
    {
        public string Name;
        public int Score;

        public Players(string PlayerName, int PlayerScore)
        {
            Name = PlayerName;
            Score = PlayerScore;//comentario
        }
    }

    public class Game
    {

        public static void Main()
        {
            int option = 1;
            
            bool exit = false;
            int index = 0;
            int games = 0;
            Players[] gamers = new Players[10];
            
            while (exit == false)
            {
                Console.Clear();
                Console.WriteLine("-------------------------");
                Console.Write("WELCOME TO TIC TAC TOE!\r\n" +
                    "1. START GAME\r\n" +
                    "2. SHOW HIGHSCORES\r\n" +
                    "3. EXIT\r\n" +
                    "Enter your choice: ");


                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid option value, please try again.");
                }
                Console.Clear();

                switch (option)
                {

                    case 1:
                        {
                            if (games < 5)
                            {
                                Console.WriteLine("-------------------------");
                                Console.WriteLine("PLAYER NAMES\r\n");
                                string name = "";
                                while (string.IsNullOrEmpty(gamers[index].Name))
                                {
                                    Console.Write("ENTER PLAYER 1 NAME: ");
                                    name = Console.ReadLine();

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
                                   name = Console.ReadLine();

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
                            }
                            else
                            {
                                Console.WriteLine("MAX NUMBER OF PLAYERS REACHED");
                            }
                            index++;
                            games++;
                            Console.Write("press ENTER to return to the menu"); Console.ReadLine();
                            break;
                        }
                    case 2:
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
                            
                            Console.WriteLine();
                            Console.Write("press ENTER to return to the menu"); Console.ReadLine();
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
                            Console.Write("press ENTER to return to the menu"); Console.ReadLine();
                            break;
                        }
                }

            }
        }
    }
}
