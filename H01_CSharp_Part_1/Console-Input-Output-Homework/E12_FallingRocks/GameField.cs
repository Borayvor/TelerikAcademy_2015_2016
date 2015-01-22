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
        private Random randomGenerator;

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

        private Random RandomGenerator
        {
            get
            {
                return this.randomGenerator;
            }

            set
            {
                this.randomGenerator = value;
            }
        }

        public void StartPlay()
        {


            while (!endOfGame)
            {
                Rock newRock = new Rock();
                newRock.SetRandom((Console.WindowWidth / 3) * 2, RandomGenerator);
                rocksList.Add(newRock);

                for (int rockIndex = 0; rockIndex < rocksList.Count; rockIndex++)
                {
                    if (rocksList[rockIndex].Y < Console.WindowHeight - 1)
                    {
                        rocksList[rockIndex].Fall();
                    }
                    else
                    {
                        rocksList[rockIndex].Clear();
                        rocksList.Remove(rocksList[rockIndex]);
                    }
                    
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

            this.RandomGenerator = new Random();

            this.rocksList = new List<Rock>();

            this.endOfGame = false;

            this.Player = new Dwarf(Console.WindowWidth / 3, Console.WindowHeight - 1,
                ConsoleColor.DarkMagenta, "(O)");

            this.Player.Print();
        }
    }
}
