using RequestTrackerBLLibrary.Interfaces;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary.BL
{
    public class RequestBL : IRequestBL
    {
        private readonly IRepository<int , Request> _repository;
        public RequestBL() {
            IRepository<int, Request> repo = new RequestRepository(new RequestTrackerContext());
            _repository = repo;
        }
        public async Task<bool> CloseRequest(int requestId, Employee employee)
        {
            var req = await _repository.Get(requestId);
            if (req != null)
            {
                req.ClosedDate = DateTime.Now;
                req.RequestStatus = "Closed";
                req.RequestClosedBy = employee.Id;
                await _repository.Update(req);
                return true;
            }
            return false;

        }

        public async Task<IList<Request>> GetAllRequests()
        {
            var reqs = await _repository.GetAll();
            if(reqs == null)
            {
                throw new Exception(message : "No Requests Found");
            }
            return reqs;

        }

        public async Task<IList<Request>> GetAllRequestsRaisedById(int requestRaisedBy)
        {
            var reqs = (await _repository.GetAll()).ToList().FindAll(rq=>rq.RequestRaisedBy == requestRaisedBy);
            if(reqs.Count == 0)
            {
                throw new Exception(message: "No Request Raised By You");
            }
            return reqs;
        }

        public Task<Request> GetRequestById(int requestID)
        {
            var req = _repository.Get(requestID);
            if(req != null)
            {
                return req;
            }
            throw new Exception(message: "Request no found");
        }

        public async Task<int> OpenRequest(Request request)
        {
            request.RequestStatus = "Open";
            var req =await _repository.Add(request);
            return req.RequestNumber;
        }
    }
}
