using CodeFirstApproach;
using RequestTrackerDALLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class RequestBL : IRequestBL
    {
        private readonly IRequestRepository _repository;
        public RequestBL()
        {
            IRequestRepository repo = new RequestRepository(new RequestTrackerContext());
            _repository = repo;
        }
        public async Task<Request> RaiseRequest(Request request)
        {

            var req = await _repository.Add(request);
            return req;
        }

        public async Task<List<Request>> ViewAllRequest()
        {
            var reqs = await _repository.GetAll();
            if(reqs == null) { }
            return reqs;
        }
        public async Task<Request> MarkRequestAsClosedById(int requestNumber, int employeeId)
        {   
            var req = await _repository.Get(requestNumber);
            if (req != null)

            {
                req.RequestStatus = "Closed";
                req.RequestClosedBy = employeeId;
                await _repository.Update(req);      
            }
            return req;

        }

        public async Task<List<Request>> GetRequestsByUserId(int userId)
        {
            return await _repository.GetByEmployeeId(userId);
        }

        public async Task<Request> GetRequestByUserId(int userId)
        {
            var req = await _repository.Get(userId);
            if(req != null)
                return req;
            throw new NotImplementedException();

        }
    }
}
