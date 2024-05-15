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
    public class FeedbackBL : IFeedbackBL
    {
        private readonly IRepository<int , SolutionFeedback > _repository;
        public FeedbackBL()
        {
            IRepository<int, SolutionFeedback> repo = new SolutionFeedbackRepository(new RequestTrackerContext());
            _repository = repo;
        }

        public async Task<SolutionFeedback> AddFeedback(SolutionFeedback feedback)
        {
            var feedbackSolution = await _repository.Add(feedback);    
            return feedbackSolution;
        }

        public async Task<IList<SolutionFeedback>> GetAllFeedbacks(int solutionId)
        {
            var feedbackSolutions = (await _repository.GetAll()).ToList().Where(fs=>fs.SolutionId == solutionId).ToList();
            if(feedbackSolutions.Count <= 0) {
                throw new Exception(message: "No Feedback Available");
            }
            return feedbackSolutions;
        }

        public Task<SolutionFeedback> GetFeedbackById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<SolutionFeedback>> GetFeedbacksByEmployee(int employeeId)
        {
            var feedbacks = (await _repository.GetAll()).ToList().Where(fs => fs.FeedbackBy == employeeId).ToList();
            if(feedbacks.Count <= 0)
            {
                throw new Exception(message: "No Feedback Available");
            }
            return feedbacks;
        }
    }
}
