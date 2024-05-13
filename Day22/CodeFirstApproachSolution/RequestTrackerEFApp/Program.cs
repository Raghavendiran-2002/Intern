using CodeFirstApproach;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerEFApp
{
    internal class Program
    {
        IEmployeeLoginBL employeeLoginBL = new EmployeeLoginBL();
        IRequestBL requestBL = new RequestBL();
        ISolutionFeedbackBL solutionFeedbackBL = new SolutionFeedbackBL();
        ISolutionBL solutionBL = new SolutionBL();
        async Task GetLoginDetails()
        {
            await Console.Out.WriteLineAsync("Please enter Employee Id");
            int id = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Please enter your password");
            string password = Console.ReadLine() ?? "";
            await EmployeeLoginAsync(id, password);
        }

        async Task RaiseRequestByEmployee(int employeeId, string content)
        {
            Request request = new Request() { RequestMessage = content, RequestStatus = "Opened", RequestRaisedBy = employeeId };
            await requestBL.RaiseRequest(request);
            UserActions(employeeId, Convert.ToInt32(Console.ReadLine()));
        }

        async Task GiveFeedBack(int employeeId)
        {
            Console.Out.WriteLine("Solution Id : ");
            int solutionId = Convert.ToInt32(Console.ReadLine());
            Console.Out.WriteLine("Rating : ");
            float rating = float.Parse(Console.ReadLine());
            Console.Out.WriteLine("Remarks : ");
            string remark = Console.ReadLine() ?? string.Empty;
            SolutionFeedback s = new SolutionFeedback() { Rating = rating, Remarks = remark, SolutionId = solutionId, FeedbackDate = DateTime.Now, FeedbackByEmployee = await employeeLoginBL.GetEmployeeById(employeeId) };
            await solutionFeedbackBL.GiveFeedback(s);
            await Console.Out.WriteLineAsync("FeedBack Registered");
        }


        async Task RespondToSolution(int employeeId)
        {
            Console.Out.WriteLine("Solution Id : ");
            int solutionId = Convert.ToInt32(Console.ReadLine());
            Console.Out.WriteLine("Request Id : ");
            int requestId = Convert.ToInt32(Console.ReadLine());
            Console.Out.WriteLine("Description : ");
            string desc = Console.ReadLine() ?? string.Empty;
            await solutionBL.ResponseToSolution(new RequestSolution() { RequestId = requestId, SolutionDescription = desc, SolvedByEmployee = await employeeLoginBL.GetEmployeeById(employeeId), RequestRaised = await requestBL.GetRequestByUserId(employeeId), IsSolved = false, SolvedDate = DateTime.Now });
        }

        async Task ProvideSolution(int employeeId)
        {
            Console.Out.WriteLine("Request Id : ");
            int requestId = Convert.ToInt32(Console.ReadLine());
            Console.Out.WriteLine("Description : ");
            string desc = Console.ReadLine() ?? string.Empty;
            var solution = new RequestSolution() { RequestId = requestId, SolutionDescription = desc, SolvedByEmployee = await employeeLoginBL.GetEmployeeById(employeeId), RequestRaised = await requestBL.GetRequestByUserId(employeeId), IsSolved = false, SolvedDate = DateTime.Now };
            await solutionBL.ProvideSolution(requestId, solution);
        }
        async Task MarkRequestAsClosed(int employeeId)
        {
            Console.Out.WriteLine("Request Id : ");
            int requestId = Convert.ToInt32(Console.ReadLine());
            requestBL.MarkRequestAsClosedById(requestId, employeeId);
        }

        async Task ViewFeedback(int employeeId)
        {
            var feedbacks = await solutionFeedbackBL.GetFeedbackByAdmin(employeeId);
            foreach (SolutionFeedback i in feedbacks)
            {
                await Console.Out.WriteLineAsync(i.ToString());
            }
        }
        async Task EmployeeLoginAsync(int username, string password)
        {
            Employee employee = new Employee() { Password = password, Id = username };

            var result = await employeeLoginBL.Login(employee);
            if (result)
            {
                await Console.Out.WriteLineAsync("Login Success");
                if (await employeeLoginBL.CheckRole(username) == "Admin")
                {

                    await Console.Out.WriteLineAsync("Admin");
                    while (true)
                    {
                        await DisplayConsoleListAdmin();
                        await AdminAction(username, Convert.ToInt32(Console.ReadLine()));
                    }
                }
                else
                {
                    await Console.Out.WriteLineAsync("User");
                    while (true)
                    {
                        await DisplayConsoleListUser();
                        await UserActions(username, Convert.ToInt32(Console.ReadLine()));
                    }
                }
            }
            else
            {
                Console.Out.WriteLine("Invalid username or password");
            }
        }
        
        async Task DisplayConsoleListUser()
        {
            Console.WriteLine("1 . Raise Request");
            Console.WriteLine("2 . View Request Status");
            Console.WriteLine("3 . View Solutions");
            Console.WriteLine("4 . Give Feedback");
            Console.WriteLine("5 . Respond To Solution");
            Console.WriteLine("6 . Logout");
        }
        async Task DisplayConsoleListAdmin()
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
        async Task AdminAction(int id, int n)
        {
            switch(n)
            {
                case 1:
                    Console.WriteLine("Request Message : ");
                    string requestMessage = Console.ReadLine();
                    await RaiseRequestByEmployee(id, requestMessage);
                    break;
                case 2:
                    var requests = requestBL.GetRequestsByUserId(id);
                    Console.WriteLine(requests);
                    break;
                case 3:
                    var sol = solutionBL.GetAllSolutionByEmployeeID(id);
                    Console.WriteLine(sol);
                    break;
                case 4:
                    await  GiveFeedBack(id);
                    break;
                case 5:
                    await  RespondToSolution(id);
                    break;
                case 6:
                    await ProvideSolution(id);
                    break;
                case 7:
                    await MarkRequestAsClosed(id);
                    break;
                case 8:
                    await ViewFeedback(id);
                    break;
                case 9:
                    return;
                default:
                    break;
            }
        }

        async Task UserActions(int id, int n ) {
            switch (n) {
                case 1:
                    Console.WriteLine("Request Message : ");
                    string requestMessage = Console.ReadLine();
                 await   RaiseRequestByEmployee(id, requestMessage);
                    break;
                case 2:
                    var requests =  requestBL.GetRequestsByUserId(id);
                    Console.WriteLine(requests);
                    break;
                case 3:
                    var sol = solutionBL.GetAllSolutionByEmployeeID(id);
                    Console.WriteLine(sol);
                    break;
                case 4:
                    await GiveFeedBack(id);
                    break;
                case 5:
                  await  RespondToSolution(id);
                    break;
                case 6:
                   await ProvideSolution(id);
                    break;
                case 7:
                    return;
                default:
                    break;
            }
                
        }
        static async Task Main(string[] args)
        {
            await new Program().GetLoginDetails();
        }
    }
}
