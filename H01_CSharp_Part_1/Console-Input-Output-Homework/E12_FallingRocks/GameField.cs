namespace E12_FallingRocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class GameField
    {
        private bool endOfGame;
        private Dwarf player;
        private List<Rock> rocksList;

        public GameField()
        {
            Initialize();            
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
            

                while (!endOfGame)
                {
                    Rock newRock = new Rock();
                    newRock.SetRandom((Console.WindowWidth / 3) * 2);
                    rocksList.Add(newRock);
                                     
                    for (int rockIndex = 0; rockIndex < rocksList.Count; rockIndex++)
                    {
                        rocksList[rockIndex].Clear();
                        rocksList[rockIndex].Y += 1;

                        if (rocksList[rockIndex].Y >= Console.WindowHeight)
                        {                            
                            rocksList.Remove(rocksList[rockIndex]);                            
                        }

                        //if (rock.Y >= Console.WindowHeight - 1)
                        //{
                        //    

                        //}


                        //if (rock.X == player.X && rock.Y == player.Y)
                        //{
                        //    player.ObjectForm = "X"; 
                        //}

                        rocksList[rockIndex].Print();
                    }

                    Thread.Sleep(150);
                }
            }

        private void Initialize()
        {
            Console.Clear();
            Console.SetWindowSize(60, 40);
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Console.CursorVisible = false;

            rocksList = new List<Rock>();

            this.endOfGame = false;

            this.Player = new Dwarf(Console.WindowWidth / 3, Console.WindowHeight - 1,
                ConsoleColor.DarkRed, "(O)");

            this.Player.Print();
        }
    }
}
