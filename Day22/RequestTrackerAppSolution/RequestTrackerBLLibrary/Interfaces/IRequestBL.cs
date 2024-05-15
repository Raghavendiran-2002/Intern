using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary.Interfaces
{
    public interface IRequestBL
    {
        public Task<int> OpenRequest(Request request);
        public Task<bool> CloseRequest(int requestId, Employee employee);


        Task<IList<Request>> GetAllRequests();
        Task<IList<Request>> GetAllRequestsRaisedById(int requestRaisedBy);

        Task <Request> GetRequestById(int requestID);
    }
}
