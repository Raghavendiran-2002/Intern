using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerApp.PrintConsole
{
    public class ConsolePrint
    {
         public async Task DisplayConsoleListUser()
        {

            Console.WriteLine("1 . Raise Request");
            Console.WriteLine("2 . View Request Status");
            Console.WriteLine("3 . View Solutions");
            Console.WriteLine("4 . Give Feedback");
            Console.WriteLine("5 . Respond To Solution");
            Console.WriteLine("6 . Logout");
        }
        public async Task DisplayConsoleListAdmin()
        {

            Console.WriteLine("1 . Raise Request");
            Console.WriteLine("2 . View Request Status");
            Console.WriteLine("3 . View Solutions");
            Console.WriteLine("4 . Give Feedback");
            Console.WriteLine("5 . Response To Solution");
            Console.WriteLine("6 . Provide Solution");
            Console.WriteLine("7 . Mark Request as Closed");
            Console.WriteLine("8 . View Feedbacks");
            Console.WriteLine("9 . Logout");
        }
    }
}
