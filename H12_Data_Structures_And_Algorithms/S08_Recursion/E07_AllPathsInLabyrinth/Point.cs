namespace E07_AllPathsInLabyrinth
{

    internal struct Point
    {
        public Point(int row, int col)
            : this()
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public int Value { get; set; }

        public override string ToString()
        {
            return "(" + this.Row + ";" + this.Col + ")";
        }
    }
}
