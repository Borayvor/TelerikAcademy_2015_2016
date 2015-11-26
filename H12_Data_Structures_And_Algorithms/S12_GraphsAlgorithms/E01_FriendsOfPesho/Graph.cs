﻿namespace E01_FriendsOfPesho
{
    using System.Collections.Generic;
    using System.Text;

    public class Graph
    {
        public Graph()
        {
            this.Nodes = new Dictionary<string, Node>();
        }

        internal IDictionary<string, Node> Nodes { get; private set; }

        public void AddNode(string name)
        {
            var node = new Node(name);
            this.Nodes.Add(name, node);
        }

        public void AddConnection(string fromNode, string toNode, int distance, bool twoWay)
        {
            this.Nodes[fromNode].AddConnection(this.Nodes[toNode], distance, twoWay);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var node in this.Nodes)
            {
                result.Append(node.Key + " -> ");

                foreach (var conection in node.Value.Connections)
                {
                    result.Append(conection.Target + "-" + conection.Distance + " ");
                }

                result.AppendLine();
            }

            return result.ToString();
        }
    }
}
