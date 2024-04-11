namespace Application
{
    internal class Program
    {
        static int num1;
        static int num2;
        static int GetNumber()
        {
            Console.WriteLine("Enter Number : ");
            return int.Parse(Console.ReadLine());
        }
        static int Sum(int n1, int n2)
        {
            return n1 + n2;
        }
        static int Product(int n1, int n2)
        {
            return n1 * n2;
        }
        static double Divide(int n1, int n2)
        {
            return (double)n1 / n2;
        }
        static int Subract(int n1, int n2)
        {
            return n2 - n1;
        }
        static int Remainder(int n1, int n2)
        {
            return n1 % n2;
        }
        static void Calculate()
        {
            num1 = GetNumber();
            num2 = GetNumber();
            Console.WriteLine($"Sum of {num1} and {num2} is {Sum(num1, num2)}");
            Console.WriteLine($"Product of {num1} and {num2} is {Product(num1, num2)}");
            Console.WriteLine($"Divide of {num1} and {num2} is {(double)Divide(num1, num2)}");
            Console.WriteLine($"Subract of {num1} and {num2} is {Subract(num1, num2)}");

            Console.WriteLine($"Remainder of {num1} and {num2} is {Remainder(num1, num2)}");

        }
        static void Main(string[] args)
        {  
            Calculate();
        }
    }
}
