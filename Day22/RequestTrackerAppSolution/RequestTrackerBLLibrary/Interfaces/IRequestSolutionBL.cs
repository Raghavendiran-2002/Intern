using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary.Interfaces
{
    public interface IRequestSolutionBL
    {
        public Task<int> AddRequestSolution(RequestSolution requestSolution);

        public Task<IList<RequestSolution>> GetRequestSolutionByEmployeeId( int employeeId);
        public Task<IList<RequestSolution>> GetAllRequestSolutions();

        public Task<IList<RequestSolution>> GetAllRequestSolutionByEmployeeId(int employeeId, int requestId);
        public Task<RequestSolution> RespondToRequestSolution(int solutionId, string solution);
    }
}
