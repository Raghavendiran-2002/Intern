using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;

namespace EmployeeRequestTrackerAPI.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRepository<int, Request> _requestRepo;

        public RequestService(IRepository<int, Request> requestRepo)
        {
            _requestRepo = requestRepo;
    
        }

        public async Task<Request> CloseRequestById(int requestId)
        {
            var req = await _requestRepo.Get(requestId);
            if(req == null)
            {
                throw new NoSuchRequestException();
            }
            req.RequestStatus = "Closed";
            req.ClosedDate = DateTime.Now;
            await _requestRepo.Update(req);
            return req;
        }

        public async Task<Request> GetEmployeeByRequestId(int requestId)
        {
            var req = await _requestRepo.Get(requestId);
            if(req == null)
            {
                throw new NoSuchRequestException();
            }
            return req;
        }

        public async Task<IEnumerable<Request>> GetRequestsByAdmin(int adminId)
        {
            var admin = (await _requestRepo.Get()).Where(r => r.RequestStatus == "Open").OrderBy(r => r.RequestDate).ToList() ;
            if (admin == null)
                throw new Exception("User doesn't exist");
           
           //     throw new Exception("Don't Have Access");
            var reqs = (await _requestRepo.Get());
            if (reqs == null)
                    throw new NoSuchRequestException();
            return reqs;  
        }

        public async Task<IEnumerable<Request>> GetRequestsByUserId(int userId)
        {
            var reqs = (await _requestRepo.Get()).Where(r=>r.RequestRaisedBy == userId).OrderBy(r=>r.RequestDate).ToList();
           
     
            if (reqs == null)
                throw new NoSuchRequestException();
            return reqs;
        }

        public async Task<Request> RaiseRequest(Request request)
        {
            await _requestRepo.Add(request);
            return request;
        }
    }
}
