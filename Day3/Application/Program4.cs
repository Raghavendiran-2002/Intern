namespace Application
{
    public class Program4
    {
        static string GetUsername()
        {
            Console.WriteLine("Enter Username : ");
            return Console.ReadLine() ?? "";
        }
        static int GetLength(string username)
        {
            return username.Length;
        }
        public static void FindUserNameLength()
        {
            string username = GetUsername();
            Console.WriteLine($"Length of Username {username} is :{GetLength(username)}");
        }
    }
}