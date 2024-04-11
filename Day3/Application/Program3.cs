namespace Application
{
    public class Program3
    {
        static double GetNumber()
        {
            double num;
            Console.WriteLine("Please enter the the number");
            while (double.TryParse(Console.ReadLine(), out num) == false)
                Console.WriteLine("Invalid entry. Please enter a number");
            return num;

        }
        public static void DivisibleBy7()
        {
            double max = 0;
            double avgDiv7 = 0;
            int avgCount = 0;
            while (true)
            {
                double input = GetNumber();
                if(input <= 0)
                {
                    break;
                }
                if(input % 7== 0)
                {
                    avgDiv7 += input;
                    avgCount++;
                }
                max = input >max ? input : max;
            }
            Console.WriteLine($"Average of {avgCount} Number divisible by 7 is : {avgDiv7 / avgCount}");
        }
    }
}