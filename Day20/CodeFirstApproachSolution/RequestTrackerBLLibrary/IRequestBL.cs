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

      //  public Task<List<Request>> RequestRaiseByEmployeeId(int EmployeeId);
        public Task<Request> MarkRequestAsClosedById(int requestNumber);

        public Task<Employee> GetRaisedByEmployee(int requestNumber);
        public Task<Employee> RequestClosedByEmployee(int requestNumber);
    }
}
