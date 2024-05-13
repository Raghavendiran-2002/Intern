using CodeFirstApproach;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface ISolutionBL
    {
        public Task<List<RequestSolution>> GetAllSolutionByEmployeeID(int employeeID);
        public Task<RequestSolution> ResponseToSolution(RequestSolution requestSolution);
        public Task<List<RequestSolution>> ViewAllSolution();

        public Task<RequestSolution> ProvideSolution(int requestId, RequestSolution requestSolution);

    }
}
