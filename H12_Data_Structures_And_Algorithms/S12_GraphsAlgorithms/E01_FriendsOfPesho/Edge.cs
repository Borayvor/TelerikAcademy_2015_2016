namespace E01_FriendsOfPesho
{
    internal class Edge
    {
        internal Edge(Node target, int distance)
        {
            this.Target = target;
            this.Distance = distance;
        }

        internal Node Target { get; private set; }

        internal int Distance { get; private set; }
    }
}
