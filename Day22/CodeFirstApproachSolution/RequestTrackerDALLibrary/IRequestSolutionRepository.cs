using CodeFirstApproach;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public interface IRequestSolutionRepository :   IRepository<int, RequestSolution>
    {
        public Task<List<RequestSolution>> GetRequestSolutionByRequest(Request requestRaised);
        public Task<List<RequestSolution>> RequestSolutionsByUserId(int userId);

        public Task<RequestSolution> AddRequestSolutionByRequestId(int requestId, RequestSolution solution);
    }
}
