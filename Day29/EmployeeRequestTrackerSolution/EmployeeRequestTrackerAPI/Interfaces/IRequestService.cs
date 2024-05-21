using EmployeeRequestTrackerAPI.Models;

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface IRequestService
    {
        public Task<Request> GetEmployeeByRequestId(int requestId);

        public Task<IEnumerable<Request>> GetRequestsByAdmin(int adminId);

        public Task<IEnumerable<Request>> GetRequestsByUserId(int userId);
        public Task<Request> CloseRequestById(int requestId);
        public Task<Request> RaiseRequest(Request request);
    }
}
