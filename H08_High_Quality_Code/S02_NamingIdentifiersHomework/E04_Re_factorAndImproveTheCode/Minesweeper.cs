namespace E04_Re_factorAndImproveTheCode
{
    using System;
    using System.Collections.Generic;

    public class Minesweeper
    {
        private const int MaxPoints = 35;

        private string command;
        private int counter;
        private int row;
        private int col;
        private bool explosion;
        private bool isEndOfGame;
        private bool isMaxResult;

        private char[,] playingField;
        private char[,] bombsOnPlayingField;
        private List<Player> champions;

        public void Start()
        {
            this.command = string.Empty;
            this.playingField = this.CreatePlayingField();
            this.bombsOnPlayingField = this.PutBombsOnPlayingField();
            this.counter = 0;
            this.row = 0;
            this.col = 0;
            this.explosion = false;
            this.isEndOfGame = true;
            this.isMaxResult = false;

            this.champions = new List<Player>(6);

            do
            {
                if (this.isEndOfGame)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si " +
                        "kasmeta da otkriesh poleteta bez mini4ki. Komanda 'top' " +
                        "pokazva klasiraneto, 'restart' po4va nova igra, 'exit' " +
                        "izliza i hajde 4ao!");

                    this.DrawBoard(this.playingField);
                    this.isEndOfGame = false;
                }

                Console.Write("Daj red i kolona : ");
                this.command = Console.ReadLine().Trim();

                if (this.command.Length >= 3)
                {
                    if (int.TryParse(this.command[0].ToString(), out this.row) &&
                        int.TryParse(this.command[2].ToString(), out this.col) &&
                        this.row <= this.playingField.GetLength(0) &&
                        this.col <= this.playingField.GetLength(1))
                    {
                        this.command = "turn";
                    }
                }

                switch (this.command)
                {
                    case "top":
                        {
                            this.Ranking(this.champions);
                            break;
                        }

                    case "restart":
                        {
                            this.playingField = this.CreatePlayingField();
                            this.bombsOnPlayingField = this.PutBombsOnPlayingField();
                            this.DrawBoard(this.playingField);
                            this.explosion = false;
                            this.isEndOfGame = false;
                            break;
                        }

                    case "exit":
                        {
                            Console.WriteLine("4a0, 4a0, 4a0!");
                            break;
                        }

                    case "turn":
                        {
                            if (this.bombsOnPlayingField[this.row, this.col] != '*')
                            {
                                if (this.bombsOnPlayingField[this.row, this.col] == '-')
                                {
                                    this.PlayerMove(this.playingField, this.bombsOnPlayingField, this.row, this.col);
                                    this.counter++;
                                }

                                if (MaxPoints == this.counter)
                                {
                                    this.isMaxResult = true;
                                }
                                else
                                {
                                    this.DrawBoard(this.playingField);
                                }
                            }
                            else
                            {
                                this.explosion = true;
                            }

                            break;
                        }

                    default:
                        {
                            Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                            break;
                        }
                }

                if (this.explosion)
                {
                    this.DrawBoard(this.bombsOnPlayingField);

                    Console.Write(
                        "\nHrrrrrr! Umria gerojski s {0} to4ki. Daj si niknejm: ",
                        this.counter);

                    string userName = Console.ReadLine().Trim();

                    Player player = new Player(userName, this.counter);

                    if (this.champions.Count < 5)
                    {
                        this.champions.Add(player);
                    }
                    else
                    {
                        for (int index = 0; index < this.champions.Count; index++)
                        {
                            if (this.champions[index].Points < player.Points)
                            {
                                this.champions.Insert(index, player);
                                this.champions.RemoveAt(this.champions.Count - 1);
                                break;
                            }
                        }
                    }

                    this.champions.Sort((Player p1, Player p2) => p2.Name.CompareTo(p1.Name));
                    this.champions.Sort((Player p1, Player p2) => p2.Points.CompareTo(p1.Points));

                    this.Ranking(this.champions);

                    this.playingField = this.CreatePlayingField();
                    this.bombsOnPlayingField = this.PutBombsOnPlayingField();

                    this.counter = 0;
                    this.explosion = false;
                    this.isEndOfGame = true;
                }

                if (this.isMaxResult)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");

                    this.DrawBoard(this.bombsOnPlayingField);

                    Console.WriteLine("Daj si imeto, batka: ");
                    string userName = Console.ReadLine().Trim();

                    Player player = new Player(userName, this.counter);

                    this.champions.Add(player);
                    this.Ranking(this.champions);

                    this.playingField = this.CreatePlayingField();
                    this.bombsOnPlayingField = this.PutBombsOnPlayingField();

                    this.counter = 0;
                    this.isMaxResult = false;
                    this.isEndOfGame = true;
                }
            }
            while (this.command != "exit");

            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private void Ranking(List<Player> players)
        {
            Console.WriteLine("\nTo4KI:");

            if (players.Count > 0)
            {
                for (int index = 0; index < players.Count; index++)
                {
                    Console.WriteLine(
                        "{0}. {1} --> {2} kutii",
                        index + 1,
                        players[index].Name,
                        players[index].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private void PlayerMove(
            char[,] playingField,
            char[,] bombsOnPlayingField, 
            int row, 
            int col)
        {
            char numberOfBombs = this.GameResult(bombsOnPlayingField, row, col);

            bombsOnPlayingField[row, col] = numberOfBombs;
            playingField[row, col] = numberOfBombs;
        }

        private void DrawBoard(char[,] board)
        {
            int boardRows = board.GetLength(0);
            int boardColumns = board.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int indexRow = 0; indexRow < boardRows; indexRow++)
            {
                Console.Write("{0} | ", indexRow);

                for (int indexColumn = 0; indexColumn < boardColumns; indexColumn++)
                {
                    Console.Write(string.Format("{0} ", board[indexRow, indexColumn]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private char[,] CreatePlayingField()
        {
            int boardRows = 5;
            int boardColumns = 10;

            char[,] board = new char[boardRows, boardColumns];

            for (int indexRow = 0; indexRow < boardRows; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < boardColumns; indexColumn++)
                {
                    board[indexRow, indexColumn] = '?';
                }
            }

            return board;
        }

        private char[,] PutBombsOnPlayingField()
        {
            int boardRows = 5;
            int boardColumns = 10;

            char[,] board = new char[boardRows, boardColumns];

            for (int indexRow = 0; indexRow < boardRows; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < boardColumns; indexColumn++)
                {
                    board[indexRow, indexColumn] = '-';
                }
            }

            List<int> bombsList = new List<int>();

            while (bombsList.Count < 15)
            {
                Random random = new Random();

                int bombCell = random.Next(50);

                if (!bombsList.Contains(bombCell))
                {
                    bombsList.Add(bombCell);
                }
            }

            foreach (int cell in bombsList)
            {
                int col = cell / boardColumns;
                int row = cell % boardColumns;

                if (row == 0 && cell != 0)
                {
                    col--;
                    row = boardColumns;
                }
                else
                {
                    row++;
                }

                board[col, row - 1] = '*';
            }

            return board;
        }

        private void CalculateBombs(char[,] bombs)
        {
            int bombsRows = bombs.GetLength(0);
            int bombsColumns = bombs.GetLength(1);

            for (int indexRow = 0; indexRow < bombsRows; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < bombsColumns; indexColumn++)
                {
                    if (bombs[indexRow, indexColumn] != '*')
                    {
                        char numberOfBombs = this.GameResult(bombs, indexRow, indexColumn);
                        bombs[indexRow, indexColumn] = numberOfBombs;
                    }
                }
            }
        }

        private char GameResult(char[,] bombs, int row, int col)
        {
            int result = 0;
            int bombsRows = bombs.GetLength(0);
            int bombsColumns = bombs.GetLength(1);

            if (row - 1 >= 0)
            {
                if (bombs[row - 1, col] == '*')
                {
                    result++;
                }
            }

            if (row + 1 < bombsRows)
            {
                if (bombs[row + 1, col] == '*')
                {
                    result++;
                }
            }

            if (col - 1 >= 0)
            {
                if (bombs[row, col - 1] == '*')
                {
                    result++;
                }
            }

            if (col + 1 < bombsColumns)
            {
                if (bombs[row, col + 1] == '*')
                {
                    result++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (bombs[row - 1, col - 1] == '*')
                {
                    result++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < bombsColumns))
            {
                if (bombs[row - 1, col + 1] == '*')
                {
                    result++;
                }
            }

            if ((row + 1 < bombsRows) && (col - 1 >= 0))
            {
                if (bombs[row + 1, col - 1] == '*')
                {
                    result++;
                }
            }

            if ((row + 1 < bombsRows) && (col + 1 < bombsColumns))
            {
                if (bombs[row + 1, col + 1] == '*')
                {
                    result++;
                }
            }

            return char.Parse(result.ToString());
        }
    }
}