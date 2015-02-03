﻿namespace E12_FallingRocks
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class GameField
    {
        private const int PLAYER_START_POINTS = 0;
        private const int PLAYER_START_LIVES = 5;

        private bool endOfGame;
        private int playGroundWidth;
        private Dwarf player;
        private List<Rock> rocksList;
        private Random randomGenerator;        
        private Scoreboard lives;
        private Scoreboard points;
       
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
            ConsoleColor[] colors = {ConsoleColor.Red, ConsoleColor.DarkCyan,
                                    ConsoleColor.Black, ConsoleColor.Blue, 
                                    ConsoleColor.Red, ConsoleColor.Magenta,
                                    ConsoleColor.DarkYellow, ConsoleColor.DarkRed, 
                                    ConsoleColor.DarkGray, ConsoleColor.DarkGreen, 
                                    ConsoleColor.DarkBlue};                       

            while (!endOfGame)
            {
                int y = 0;
                int x = randomGenerator.Next(0, this.playGroundWidth);

                ConsoleColor color = colors[randomGenerator.Next(0, colors.Length)];                                

                Rock newRock = new Rock(x, y, color, randomGenerator);
                this.rocksList.Add(newRock);

                for (int rockIndex = 0; rockIndex < this.rocksList.Count; rockIndex++)
                {
                    if (this.rocksList[rockIndex].Y < Console.WindowHeight - 1)
                    {
                        // this.rocksList[rockIndex].Fall();
                    }
                    else
                    {
                        if (this.rocksList[rockIndex].X >= this.Player.X &&
                            this.rocksList[rockIndex].X < this.Player.X + this.Player.ObjectForm.Length)
                        {
                            this.lives.Amount--;
                            //this.lives.Draw();

                            //this.Player.Clear();
                            //this.Player.ObjectForm = PLAYER_DEAD_FORM;
                            //this.Player.Draw();

                            //Thread.Sleep(700);

                            //this.Player.Clear();
                            //this.Player.ObjectForm = PLAYER_LIVE_FORM;
                            //this.Player.Draw();

                            if (this.lives.Amount == 0)
                            {
                                this.endOfGame = true;
                            }
                           
                        }
                        else
                        {                            
                            this.points.Amount++;
                            //this.points.Draw();                           
                        }

                        //this.Player.Draw();
                        //this.rocksList[rockIndex].Clear();
                        this.rocksList.Remove(this.rocksList[rockIndex]);                        
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

            this.playGroundWidth = ((Console.WindowWidth / 3) * 2) + 2;

            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(playGroundWidth, i);
                Console.Write("|");
            }

            this.lives = new Scoreboard(this.playGroundWidth + 3, 10,
                ConsoleColor.White, "LIVES", PLAYER_START_LIVES);
            this.points = new Scoreboard(this.playGroundWidth + 3, 4,
                ConsoleColor.White, "POINTS", PLAYER_START_POINTS);

            this.Player = new Dwarf(Console.WindowWidth / 3, Console.WindowHeight - 1,
                ConsoleColor.DarkMagenta);

            //this.lives.Draw();
            //this.points.Draw();
            //this.Player.Draw();
        }
    }
}
