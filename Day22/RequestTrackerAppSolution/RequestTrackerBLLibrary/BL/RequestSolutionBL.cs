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
    public class RequestSolutionBL : IRequestSolutionBL
    {
        private readonly IRepository<int, RequestSolution> _repository;
       private readonly IRequestBL _requestBL;
        public RequestSolutionBL() { 
            IRepository<int , RequestSolution> repo = new RequestSolutionRepository(new RequestTrackerContext());
            _repository = repo;
        }

        public RequestSolutionBL(IRequestBL requestBLs)
        {
            IRepository<int, RequestSolution> repo = new RequestSolutionRepository(new RequestTrackerContext());
            _repository = repo;
            _requestBL = requestBLs;
        }
        public async Task<int> AddRequestSolution(RequestSolution requestSolution)
        {
            var req = await _repository.Add(requestSolution);
            return req.SolutionId;
        }

        public async Task<IList<RequestSolution>> GetAllRequestSolutionByEmployeeId(int employeeId, int requestId)
        {
            var reqs = (await _repository.GetAll()).ToList().Where(rs => rs.SolvedBy == employeeId).Where(r=>r.RequestId == requestId).ToList();
            if (reqs.Count() == 0)
            {
                throw new Exception(message: "No solution provided By admin");
            }
            return reqs;
        }

        public async Task<IList<RequestSolution>> GetAllRequestSolutions()
        {
            var reqs = (await _repository.GetAll()).ToList();
            if (reqs.Count() == 0)
                throw new Exception(message: "No Solution Available");
            return reqs;
        }

        public async Task<IList<RequestSolution>> GetRequestSolutionByEmployeeId(int employeeId)
        {
            var reqSol = (await _repository.GetAll()).ToList().Where(rs => rs.SolvedBy == employeeId).ToList();
            if (reqSol.Count() == 0)
                throw new Exception(message: "No Request Solution Available");
            return reqSol;
        }

        public async Task<RequestSolution> RespondToRequestSolution(int solutionId, string solution)
        {
            var reqSol = await _repository.Get(solutionId);
            if (reqSol == null)
                throw new Exception(message: "Solution Not Found");
            reqSol.SolutionDescription = solution;
            await _repository.Update(reqSol);
            return reqSol;
        }
    }
}
