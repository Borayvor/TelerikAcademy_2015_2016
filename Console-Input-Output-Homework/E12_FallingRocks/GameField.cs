namespace E12_FallingRocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GameField
    {
        private bool endOfGame;
        private Dwarf player;
        private ICollection<Rock> rocksList;

        public GameField()
        {
            Initialize();
            rocksList = new List<Rock>();
        }

        public Dwarf Player
        {
            get 
            {
                return this.player;
            }

            set
            {
                this.player = value;
            }
        }

        public void StartPlay()
        {
            Rock newRock = new Rock();
                newRock.SetRandom((Console.WindowWidth / 3) * 2);
                rocksList.Add(newRock);

                while (!endOfGame)
                {
                    foreach (var rock in rocksList)
                    {
                        rock.Y += 1;

                        if (rock.Y >= Console.WindowHeight)
                        {
                            rocksList.Remove(rock);
                            
                        }


                        if (rock.X == player.X && rock.Y == player.Y)
                        {
                            player.ObjectForm = "X";
                            
                           
                        }
                    }
                }
            }

        private void Initialize()
        {
            Console.Clear();
            Console.SetWindowSize(60, 40);
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Console.CursorVisible = false;

            this.endOfGame = false;

            this.Player = new Dwarf(Console.WindowWidth / 3, Console.WindowHeight - 1,
                ConsoleColor.DarkRed, "(O)");

            this.Player.Print();
        }
    }
}
