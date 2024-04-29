using MinimumDepthOfBinaryTree;

namespace LeetCode
{
    internal class Program
    {
        public void MinimumDepthOfBinaryTree(){
            BinaryTree bt = new BinaryTree();
            Console.WriteLine( "Minimum Depth Of Binary Tree : "+bt.MinDepth(bt.tree));
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.MinimumDepthOfBinaryTree();
        }
    }
}
