namespace MinimumDepthOfBinaryTree
{
    public class BinaryTree
    {
        public Node tree;

        public BinaryTree()
        {   
            tree = new Node(2);
            tree.left = new Node(4);
            tree.right = new Node(6);
            tree.left.left = new Node(8);
            tree.left.right = new Node(10);
        }
        public int MinDepth(Node tree)
        {
            if (tree == null)
                return 0;
            if (tree.right == null && tree.right == null)
                return 1;
            if (tree.left == null)
                return MinDepth(tree.right) + 1;
            if(tree.right == null)
                return MinDepth(tree.left) + 1;
            return Math.Min(MinDepth(tree.right), MinDepth(tree.left)) + 1; 
        }
    }
}
