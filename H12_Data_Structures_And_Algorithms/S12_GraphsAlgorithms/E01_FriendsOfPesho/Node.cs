namespace E01_FriendsOfPesho
{
    using System;
    using System.Collections.Generic;

    internal class Node : IComparable<Node>
    {
        internal Node(string name)
        {
            this.Name = name;
            this.Connections = new List<Edge>();
        }
        
        public int DijkstraDistance { get; set; }

        public bool IsHospital { get; set; }

        internal string Name { get; }

        internal IList<Edge> Connections { get; }

        public int CompareTo(Node other)
        {
            return this.DijkstraDistance.CompareTo(other.DijkstraDistance);
        }

        public override string ToString()
        {
            return this.Name;
        }

        internal void AddConnection(Node targetNode, int distance, bool twoWay)
        {
            if (targetNode == null)
            {
                throw new ArgumentNullException("targetNode");
            }

            if (targetNode == this)
            {
                throw new ArgumentException("Node may not connect to itself.");
            }

            if (distance <= 0)
            {
                throw new ArgumentException("Distance must be positive.");
            }

            this.Connections.Add(new Edge(targetNode, distance));

            if (twoWay)
            {
                targetNode.AddConnection(this, distance, false);
            }
        }
    }
}