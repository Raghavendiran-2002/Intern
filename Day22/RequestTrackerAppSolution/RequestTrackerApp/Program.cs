using RequestTrackerApp.PrintConsole;
using RequestTrackerBLLibrary.BL;
using RequestTrackerBLLibrary.Interfaces;
using RequestTrackerModelLibrary;

namespace RequestTrackerApp
{
    internal class Program
    {
       
        readonly IEmployeeLoginBL employeeLoginBL = new EmployeeLoginBL();
        readonly IRequestBL requestBL = new RequestBL();
        readonly IFeedbackBL feedbackBL = new FeedbackBL();
        readonly IRequestSolutionBL solutionBL = new RequestSolutionBL();
        public Employee employee;
         async Task EmployeeLoginAsync(int username, string password)
        {
             employee = new Employee() { Password = password, Id = username };

            var result = await employeeLoginBL.Login(employee);
            if (result != null)
            {
                await Console.Out.WriteLineAsync("Login Success");
                if (await employeeLoginBL.CheckRole(username) == "Admin")
                {
                    await Console.Out.WriteLineAsync("Admin");
                    bool validUser = true;
                    while (validUser)
                    {
                        if (employee == null)
                            validUser = false;
                        await DisplayConsoleListAdmin();
                        await AdminAction(employee, Convert.ToInt32(Console.ReadLine()));
                    }
                    await new Program().GetLoginDetails();
                }
                else
                {
                    await Console.Out.WriteLineAsync("User");
                    bool validUser = true;
                    while (validUser)
                    {
                        if (employee == null)                      
                            validUser = false;
                        await DisplayConsoleListUser();
                        await UserActions(employee, Convert.ToInt32(Console.ReadLine()));
                    }
                    await new Program().GetLoginDetails();
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
            Console.WriteLine("2 . View Request Status ( All Requests )");
            Console.WriteLine("3 . View Solutions");
            Console.WriteLine("4 . Give Feedback");
            Console.WriteLine("5 . Response To Solution");
            Console.WriteLine("6 . Provide Solution");
            Console.WriteLine("7 . Mark Request as Closed");
            Console.WriteLine("8 . View Feedbacks");
            Console.WriteLine("9 . Logout");
        }
        async Task AdminAction(Employee? employee, int n)
        {
            switch (n)
            {
                case 1:
                    await Console.Out.WriteLineAsync(employee.Id + ".");
                    await Console.Out.WriteLineAsync("message : ");
                    string msg = Console.ReadLine() ?? "";  
                    await requestBL.OpenRequest(new Request() { RequestMessage = msg, RequestDate = DateTime.Now , RequestStatus = "Opened",RequestRaisedBy = employee.Id});
                    await Console.Out.WriteLineAsync("SuccessFully Added");
                    break;
                case 2:
                    var requests =await requestBL.GetAllRequests();
                    foreach(Request request in requests)
                    {
                        await Console.Out.WriteLineAsync(request.ToString());
                    }
                    break;
                case 3:
                    var solution = await solutionBL.GetAllRequestSolutions();
                    foreach (RequestSolution sol in solution)
                    {
                        await Console.Out.WriteLineAsync(sol.ToString());
                    }
                    break;
                case 4:
                    await Console.Out.WriteLineAsync("Solution Id : ");
                    int solId = Convert.ToInt32(Console.ReadLine());
                    await Console.Out.WriteLineAsync("Remark : ");
                    string remark = Console.ReadLine() ?? "";
                    await Console.Out.WriteLineAsync("Rating(Float) : ");
                    float rating = float.Parse(Console.ReadLine());
                    var feedbackSolution = new SolutionFeedback() { Rating = rating, Remarks = remark,SolutionId = solId, FeedbackBy= employee.Id,FeedbackDate = DateTime.Now};
                    await feedbackBL.AddFeedback(feedbackSolution);
                    break;
                case 5:
                    await Console.Out.WriteLineAsync("Solution Id : ");
                    int solutionId = Convert.ToInt32(Console.ReadLine());
                    await Console.Out.WriteLineAsync("Description : ");
                    string description = Console.ReadLine();
                    await solutionBL.RespondToRequestSolution( solutionId,  description);
                    break;
                case 6:
                    await Console.Out.WriteLineAsync("Request Id : ");
                    int rqId = Convert.ToInt32(Console.ReadLine());
                    await Console.Out.WriteLineAsync("Description : ");
                    string solDes = Console.ReadLine();
                    RequestSolution requestSolution = new RequestSolution() {  RequestId = rqId, SolutionDescription = solDes, SolvedBy = employee.Id, IsSolved = true, SolvedDate = DateTime.Now };
                    await solutionBL.AddRequestSolution(requestSolution);
                    break;
                case 7:
                    await Console.Out.WriteLineAsync("Request Id : ");
                    int reqId = Convert.ToInt32(Console.ReadLine());
                    await requestBL.CloseRequest(reqId, employee);
                    break;

                case 8:
                    var solutions = await feedbackBL.GetFeedbacksByEmployee(employee.Id);
                    foreach(SolutionFeedback rs in solutions)
                    {
                        await Console.Out.WriteLineAsync(rs.ToString());
                    }
                    break;
                case 9:
                    employee = null;
                    return;            
                default:
                    break;
            }
        }

        async Task UserActions(Employee? employee, int n)
        {
            switch (n)
            {
                case 1:
                    await Console.Out.WriteLineAsync("message : ");
                    string msg = Console.ReadLine() ?? "";
                    await requestBL.OpenRequest(new Request() { RequestMessage = msg, RequestDate = DateTime.Now, RequestStatus = "Opened", RequestRaisedBy = employee.Id });
                    await Console.Out.WriteLineAsync("SuccessFully Added");
                    break;
                case 2:
                    var requests = await requestBL.GetAllRequestsRaisedById(employee.Id);
                    foreach (Request request in requests)
                    {
                        await Console.Out.WriteLineAsync(request.ToString());
                    }
                    break;
                case 3:
                    int requestId = Convert.ToInt32(Console.ReadLine());
                    var solution = await solutionBL.GetAllRequestSolutionByEmployeeId(employee.Id, requestId);
                    foreach (RequestSolution sol in solution)
                    {
                        await Console.Out.WriteLineAsync(sol.ToString());
                    }
                    break;
                case 4:
                    var solutions = await solutionBL.GetRequestSolutionByEmployeeId(employee.Id);
                    foreach (RequestSolution sol in solutions)
                    {
                        await Console.Out.WriteLineAsync(sol.ToString());
                    }
                    await Console.Out.WriteLineAsync("Solution Id : ");
                    int solId = Convert.ToInt32(Console.ReadLine());
                    await Console.Out.WriteLineAsync("Remark : ");
                    string remark = Console.ReadLine() ?? "";
                    await Console.Out.WriteLineAsync("Rating(Float) : ");
                    float rating = float.Parse(Console.ReadLine());
                    var feedbackSolution = new SolutionFeedback() { Rating = rating, Remarks = remark, SolutionId = solId, FeedbackBy = employee.Id, FeedbackDate = DateTime.Now };
                    await feedbackBL.AddFeedback(feedbackSolution);
                    break;
                case 5:
                    await Console.Out.WriteLineAsync("Solution Id : ");
                    int solutionId = Convert.ToInt32(Console.ReadLine());
                    await Console.Out.WriteLineAsync("Description : ");
                    string description = Console.ReadLine();
                    await solutionBL.RespondToRequestSolution(solutionId, description);
                    break;
                case 6:
                    employee = null;
                    return;

                default:
                    break;
            }

        }
        async Task GetLoginDetails()
        {
            await Console.Out.WriteLineAsync("Please enter Employee Id");
            int id = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Please enter your password");
            string password = Console.ReadLine() ?? "";
            await EmployeeLoginAsync(id, password);
        }

        static async Task Main(string[] args)
        {
            await new Program().GetLoginDetails();
        }
    }
}
