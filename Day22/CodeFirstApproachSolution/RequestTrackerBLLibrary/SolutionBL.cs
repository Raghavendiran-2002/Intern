using CodeFirstApproach;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class SolutionBL : ISolutionBL
    {
        private readonly IRequestSolutionRepository _repository;
        public SolutionBL()
        {
            IRequestSolutionRepository repo = new RequestSolutionRepository(new RequestTrackerContext());
            _repository = repo;
        }  
        public async Task<List<RequestSolution>> GetAllSolutionByEmployeeID(int employeeID)
        {
            var reqSolve = await _repository.RequestSolutionsByUserId(employeeID);
            if(reqSolve == null) { }
            return reqSolve;

        }

        public async Task<RequestSolution> ProvideSolution(int requestId, RequestSolution requestSolution)
        {
            var req = await _repository.AddRequestSolutionByRequestId(requestId, requestSolution);
            if(req  == null) { }
            return req;
        }

        public Task<RequestSolution> ResponseToSolution(RequestSolution requestSolution)
        {
           
            throw new NotImplementedException();
        }

        public Task<List<RequestSolution>> ViewAllSolution()
        {
            throw new NotImplementedException();
        }
    }
}
