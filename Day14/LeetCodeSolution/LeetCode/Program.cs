using ExcelSheetColumnTitle;
using LinkedListCycle;
using MinimumDepthOfBinaryTree;

namespace LeetCode
{
    internal class Program
    {
        public void MinimumDepthOfBinaryTree(){
            BinaryTree bt = new BinaryTree();
            Console.WriteLine( "Minimum Depth Of Binary Tree : "+bt.MinDepth(bt.tree));
        }

        public void ExcelSheetColumnTitles(int index)
        {
            FindColumnTitle ex = new FindColumnTitle(index);
            Console.WriteLine($"Column Number : {index} TitleInExcelSheet  : {ex.FindColumnTitleUsingNumber()}");

        }
        public void LinkedListCycle()
        {
            DetectCycleInLinkedList detectcycle = new DetectCycleInLinkedList();
            Console.WriteLine($"Is Cycle Detected  : {detectcycle.HasCycle()}, Detected At : {detectcycle.JoiningPoint}");
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.MinimumDepthOfBinaryTree();
            program.ExcelSheetColumnTitles(28);
            program.LinkedListCycle();
        }
    }
}
