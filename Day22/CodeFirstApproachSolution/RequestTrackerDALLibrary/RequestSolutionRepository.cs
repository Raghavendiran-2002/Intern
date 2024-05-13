using CodeFirstApproach;
using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class RequestSolutionRepository : IRequestSolutionRepository
    {
        private readonly RequestTrackerContext _context;
        public RequestSolutionRepository(RequestTrackerContext context)
        {
            _context = context;
        }

        public async Task<RequestSolution> Add(RequestSolution entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity; 
        }

        public async Task<RequestSolution> AddRequestSolutionByRequestId(int requestId, RequestSolution solution)
        {
            var req = _context.Requests.SingleOrDefault(x => x.RequestNumber == requestId);
            if(req == null)
            {
                
            }
            solution.RequestId = req.RequestNumber;
            _context.Add(solution);
            await _context.SaveChangesAsync();
            return solution;
        }

        public async Task<RequestSolution> Delete(int key)
        {
            var requestSolution = await Get(key);
            if(requestSolution != null)
            {
                _context.RequestSolutions.Remove(requestSolution);
                _context.SaveChanges();
            }
            return requestSolution;
        }

        public async Task<RequestSolution> Get(int key)
        {
            var requestSolution = _context.RequestSolutions.SingleOrDefault(rs => rs.SolutionId == key);
            return requestSolution;
        }

        public async Task<List<RequestSolution>> GetAll()
        {
            return await _context.RequestSolutions.ToListAsync();
        }
        public async Task<List<RequestSolution>> GetRequestSolutionByRequest(Request requestRaised)
        {
            return await _context.RequestSolutions.Where(rs => rs.RequestRaised == requestRaised).ToListAsync();
        }

        public async Task<List<RequestSolution>> RequestSolutionsByUserId(int userId)
        {
            return await _context.RequestSolutions.Where(r => r.SolvedByEmployee.Id == userId).ToListAsync();
        }

        public async Task<RequestSolution> Update(RequestSolution entity)
        {
            var requestSolution = await Get(entity.SolutionId);
            if(requestSolution != null) {
                _context.Entry<RequestSolution>(requestSolution).State = EntityState.Modified;
               await _context.SaveChangesAsync();
            }
            return requestSolution;
        }
    }
}
