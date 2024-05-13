using CodeFirstApproach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IRequestBL
    {
        public Task<Request> RaiseRequest( Request request);
        public Task<List<Request>> ViewAllRequest();
        public Task<Request> MarkRequestAsClosedById(int requestNumber, int employeeId);
        public Task<List<Request>> GetRequestsByUserId(int userId);
        public Task<Request> GetRequestByUserId(int userId);
    }
}
