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
        private readonly IRepository<int, Request> _repositoryRequest;
        private readonly IRepository<int, Employee> _repositoryEmployee;

        public RequestBL()
        {
            IRepository<int, Request> repo = new RequestRepository(new RequestTrackerContext());
            _repositoryRequest = repo;
            IRepository<int, Employee> emp = new EmployeeRepository(new RequestTrackerContext());
            _repositoryEmployee = emp;
        }
        public async Task<Request> RaiseRequest(Request request)
        {

            var req = await _repositoryRequest.Add(request);
            return req;
        }

        //public async Task<List<Request>> RequestRaiseByEmployeeId(int employeeId,Request request)
        //{
            
         //   var emp = await _repositoryEmployee.Get(employeeId);

       // }

        public Task<List<Request>> ViewAllRequest()
        {
            throw new NotImplementedException();
        }
        public async Task<Request> MarkRequestAsClosedById(int requestNumber)
        {
            var req = await _repositoryRequest.Get(requestNumber);
            if(req != null)
            {
            }
            return req;

        }

        public async Task<Employee> GetRaisedByEmployee(int requestNumber)
        {
            var emp = await _repositoryRequest.Get(requestNumber);
            if (emp == null) { }
                //raise exception
            return emp.RaisedByEmployee;
        }

        public async Task<Employee> RequestClosedByEmployee(int requestNumber)
        {
            var emp = await _repositoryRequest.Get(requestNumber);
            if (emp == null) { }
            //raise exception
            return emp.RequestClosedByEmployee;
        }
    }
}
