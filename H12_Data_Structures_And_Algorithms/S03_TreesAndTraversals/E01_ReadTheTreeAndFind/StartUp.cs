namespace E01_ReadTheTreeAndFind
{
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var myTree = new List<Node<int>>();

            TreeUtils.BuildTree(myTree);

            // 1. Find the root node.
            TreeUtils.FindRoot(myTree);

            // 2. Find all leaf nodes.
            TreeUtils.FindAllLeafs(myTree);

            // 3. Find all middle nodes.
            TreeUtils.FindMiddleNodes(myTree);

            // 4. Find the longest path.
            TreeUtils.FindLongestPath(myTree);

            // 5. Find all paths in the tree with given sum `S` of their nodes.
            TreeUtils.FindPathsWithSum(6, myTree);

            // 6. Find all subtrees with given sum `S` of their nodes.
            TreeUtils.FindSubTreesWithSum(6, myTree);
        }
    }
}
