namespace Application
{
	public class Program2
	{
		static int num, temp = 0;
		static int GetNumber()
		{
			int num1;
			Console.WriteLine("Please enter the the number");
			while (int.TryParse(Console.ReadLine(), out num1) == false)
				Console.WriteLine("Invalid entry. Please enter a number");
			return num1;

		}
		public static void GreatestNumber()
		{
			temp = GetNumber();
			while (temp >= 0)
			{
				if (temp > num)
				{
					num = temp;
				}
				temp = GetNumber();
			}
			Console.WriteLine($"Greatest Number so far is : {num}");
		}
	}
}