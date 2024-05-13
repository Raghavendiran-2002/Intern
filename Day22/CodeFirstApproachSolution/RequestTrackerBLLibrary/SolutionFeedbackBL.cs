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
    public class SolutionFeedbackBL : ISolutionFeedbackBL
    {
        private readonly ISolutionFeedbackRepository _repository;

        public SolutionFeedbackBL()
        {
            ISolutionFeedbackRepository repo = new SolutionFeedbackRepository(new RequestTrackerContext());
            _repository = repo;
        }
        public async Task<List<SolutionFeedback>> GetFeedbackByAdmin(int adminId)
        {
            var adminSolution = await _repository.GetFeedbackByEmployeeId(adminId);
            if(adminSolution == null) { }
            return adminSolution;
        }

        public async Task<SolutionFeedback> GiveFeedback(SolutionFeedback solutionfeedback)
        {
            var feed = await _repository.Add(solutionfeedback);
            if (feed == null) { }
            return feed;

        }
    }
}
