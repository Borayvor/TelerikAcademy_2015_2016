namespace E01_ReadTheTreeAndFind
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeUtils
    {
        public static void BuildTree(IList<Node<int>> myTree)
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N - 1; i++)
            {
                var tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var parentValue = tokens[0];
                var parentNode = myTree.FirstOrDefault(x => x.Value == parentValue);

                if (parentNode == null)
                {
                    parentNode = new Node<int>(parentValue);
                    myTree.Add(parentNode);
                }

                var childValue = tokens[1];
                var childNode = myTree.FirstOrDefault(x => x.Value == childValue);

                if (childNode == null)
                {
                    childNode = new Node<int>(childValue);
                    myTree.Add(childNode);
                }

                parentNode.Children.Add(childNode);

                childNode.Parent = parentNode;
            }
        }

        public static Node<int> FindRoot(IList<Node<int>> myTree)
        {
            var nodes = myTree.Where(x => x.Parent == null);

            if (nodes.Count() != 1)
            {
                throw new ArgumentException("There are invalid number of roots in this tree!");
            }

            var theRoot = nodes.First();

            Console.WriteLine("The root is " + theRoot.ToString());
            Console.WriteLine();

            return theRoot;
        }

        public static void FindAllLeafs(IList<Node<int>> myTree)
        {
            Console.Write("All leafs are: ");

            Console.WriteLine(string.Join(", ", myTree
                .Where(x => x.Children.Count == 0)
                .Select(x => x.Value)));
            Console.WriteLine();
        }

        public static void FindMiddleNodes(IList<Node<int>> myTree)
        {
            Console.Write("All middle nodes are: ");

            Console.WriteLine(string.Join(", ", myTree
                .Where(x => x.Children.Count > 0 && x.Parent != null)
                .Select(x => x.Value)));
            Console.WriteLine();
        }

        public static void FindLongestPath(IList<Node<int>> myTree)
        {
            var leafs = myTree.Where(x => x.Children.Count == 0);

            var longestPaths = new List<int[]>();

            foreach (var leaf in leafs)
            {
                var paths = new List<List<int>>();
                var visited = new bool[myTree.Count];
                visited[leaf.Value] = true;

                GetPathsFromNode(leaf, new List<int>() { leaf.Value }, visited, paths);

                if (longestPaths.Count > 0 && paths[0].Count > longestPaths[0].Length)
                {
                    longestPaths.Clear();
                }

                if (longestPaths.Count == 0 || paths[0].Count == longestPaths[0].Length)
                {
                    foreach (var path in paths)
                    {
                        longestPaths.Add(path.ToArray());
                    }
                }
            }

            Console.WriteLine("All maximum paths have length of {0} and are: ", longestPaths[0].Length);
            Console.WriteLine(string.Join(Environment.NewLine, longestPaths.Select(x => string.Join(" -> ", x))));
            Console.WriteLine();
        }

        public static void FindPathsWithSum(int sum, IList<Node<int>> myTree)
        {
            var pathsWithSum = new List<int[]>();

            foreach (var node in myTree)
            {
                var pathsFromThisNode = new List<List<int>>();
                var visitedNodes = new bool[myTree.Count];
                visitedNodes[node.Value] = true;

                GetPathsWithSumFromNode(node, sum, node.Value, new List<int>() { node.Value }, visitedNodes, pathsFromThisNode);

                pathsWithSum.AddRange(pathsFromThisNode.Select(x => x.ToArray()));
            }

            Console.WriteLine("All paths that have sum of {0} are: ", sum);
            Console.WriteLine(string.Join(Environment.NewLine, pathsWithSum.Select(x => string.Join(" -> ", x))));
            Console.WriteLine();
        }

        public static void FindSubTreesWithSum(int sum, IList<Node<int>> myTree)
        {
            var rootsOfSubtreesWithSum = new List<Node<int>>();

            foreach (var node in myTree)
            {
                var subtreeSum = GetSumOfSubTreeWithRoot(node);

                if (subtreeSum == sum)
                {
                    rootsOfSubtreesWithSum.Add(node);
                }
            }

            Console.WriteLine("All subtrees that have sum of {0} are: ", sum);
            foreach (var subRoot in rootsOfSubtreesWithSum)
            {
                PrintFromRoot(subRoot, 0);
                Console.WriteLine(new string('-', 40));
            }
            Console.WriteLine();
        }

        private static void PrintFromRoot(Node<int> root, int offset)
        {
            Console.Write(new string('-', offset) + root.Value);

            if (offset == 0)
            {
                Console.Write(" <- (root)");
            }

            Console.WriteLine();

            foreach (var child in root.Children)
            {
                PrintFromRoot(child, offset + 2);
            }
        }

        private static int GetSumOfSubTreeWithRoot(Node<int> node)
        {
            return GetSumFromNode(node);
        }

        private static int GetSumFromNode(Node<int> node)
        {
            if (node.Children.Count == 0)
            {
                return node.Value;
            }
            else
            {
                return node.Children.Select(GetSumFromNode).Sum() + node.Value;
            }
        }

        private static void GetPathsWithSumFromNode(Node<int> node, int sum, int sumSoFar, List<int> pathSoFar, bool[] visitedNodes, List<List<int>> pathsFromThisNode)
        {
            if (sumSoFar == sum)
            {
                pathsFromThisNode.Add(pathSoFar.ToList());
            }

            if (sumSoFar > sum)
            {
                return;
            }

            foreach (var child in node.Children)
            {
                if (!visitedNodes[child.Value])
                {
                    visitedNodes[child.Value] = true;
                    pathSoFar.Add(child.Value);

                    GetPathsWithSumFromNode(child, sum, sumSoFar + child.Value, pathSoFar, visitedNodes, pathsFromThisNode);

                    visitedNodes[child.Value] = false;
                    pathSoFar.Remove(child.Value);
                }
            }

            if (node.Parent != null && !visitedNodes[node.Parent.Value])
            {
                visitedNodes[node.Parent.Value] = true;
                pathSoFar.Add(node.Parent.Value);

                GetPathsWithSumFromNode(node.Parent, sum, sumSoFar + node.Parent.Value, pathSoFar, visitedNodes, pathsFromThisNode);

                visitedNodes[node.Parent.Value] = false;
                pathSoFar.Remove(node.Parent.Value);
            }
        }

        private static void GetPathsFromNode(Node<int> node, IList<int> pathSoFar, bool[] visited, IList<List<int>> maxPaths)
        {
            if (maxPaths.Count > 0 && pathSoFar.Count > maxPaths[0].Count)
            {
                maxPaths.Clear();
            }

            if (maxPaths.Count == 0 || pathSoFar.Count == maxPaths[0].Count)
            {
                maxPaths.Add(pathSoFar.ToList());
            }

            foreach (var child in node.Children)
            {
                if (!visited[child.Value])
                {
                    visited[child.Value] = true;
                    pathSoFar.Add(child.Value);

                    GetPathsFromNode(child, pathSoFar, visited, maxPaths);

                    visited[child.Value] = false;
                    pathSoFar.Remove(child.Value);
                }
            }

            if (node.Parent != null && !visited[node.Parent.Value])
            {
                visited[node.Parent.Value] = true;
                pathSoFar.Add(node.Parent.Value);

                GetPathsFromNode(node.Parent, pathSoFar, visited, maxPaths);

                visited[node.Parent.Value] = false;
                pathSoFar.Remove(node.Parent.Value);
            }
        }


    }
}
