namespace E01_FriendsOfPesho
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            string input = @"3 2 1 
1
1 2 1
3 2 2
";

            Console.SetIn(new StringReader(input));

            Graph graph = new Graph();

            string[] townInfo = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int numberOfRoads = int.Parse(townInfo[1]);

            HashSet<string> hospitals =
                new HashSet<string>(Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            for (int i = 0; i < numberOfRoads; i++)
            {
                string[] roadsInfo = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string from = roadsInfo[0];
                string to = roadsInfo[1];
                int distance = int.Parse(roadsInfo[2]);

                if (!graph.Nodes.ContainsKey(from))
                {
                    graph.AddNode(from);
                }

                if (!graph.Nodes.ContainsKey(to))
                {
                    graph.AddNode(to);
                }

                graph.AddConnection(from, to, distance, true);

                if (hospitals.Contains(from))
                {
                    graph.Nodes[from].IsHospital = true;
                }

                if (hospitals.Contains(to))
                {
                    graph.Nodes[to].IsHospital = true;
                }
            }

            Console.WriteLine("===============================");
            Console.WriteLine(graph);

            int minDistance = hospitals
                .Select(hospital => Dijkstra(graph.Nodes, hospital))
                .Concat(new[] { int.MaxValue }).Min();

            Console.WriteLine("===============================");
            Console.WriteLine(minDistance);
            Console.WriteLine();
        }

        private static int Dijkstra(IDictionary<string, Node> graph, string hospital)
        {
            foreach (var point in graph)
            {
                point.Value.DijkstraDistance = int.MaxValue;
            }

            graph[hospital].DijkstraDistance = 0;

            PriorityQueue<Node> nodes = new PriorityQueue<Node>();

            nodes.Enqueue(graph[hospital]);

            while (nodes.Count > 0)
            {
                Node currentNode = nodes.Dequeue();

                foreach (var item in currentNode.Connections)
                {
                    int potentialDistance = currentNode.DijkstraDistance + item.Distance;

                    if (potentialDistance < item.Target.DijkstraDistance)
                    {
                        item.Target.DijkstraDistance = potentialDistance;
                        nodes.Enqueue(item.Target);
                    }
                }
            }

            return graph
                .Where(item => !item.Value.IsHospital
                && item.Value.DijkstraDistance != int.MaxValue)
                .Sum(item => item.Value.DijkstraDistance);
        }
    }
}
