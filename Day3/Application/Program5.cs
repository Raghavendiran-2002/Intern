namespace Application
{
    public class Program5
    {
        static int retry = 2;
        static bool Auth(string username, string password) 
        {
            return (username == "ABC" && password == "123");
            
        }
        static void GetUsernamePassword(string username, string password)
        {
            Console.WriteLine("Enter Username : ");
            username  = Console.ReadLine();
            Console.WriteLine("Enter Password : ");
            password = Console.ReadLine();
        }
        public static void Login()
        {
            string username = " ",password = " ";

            while (retry != 0)
            {   
                GetUsernamePassword(username, password);
                if (Auth(username, password))
                {
                    Console.WriteLine("Logged in Successfully");
                    break;
                }
                else
                {
                    Console.WriteLine($"Username and Password is Incorrect!!! You still have {retry} attempts");
                }
                retry--;
            }
            Console.WriteLine("Your attempts are over!!!");
        }
    }
}