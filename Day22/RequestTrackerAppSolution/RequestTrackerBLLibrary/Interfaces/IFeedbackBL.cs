using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary.Interfaces
{
    public interface IFeedbackBL
    {
        Task<SolutionFeedback> AddFeedback(SolutionFeedback feedback);
        Task<SolutionFeedback> GetFeedbackById(int id);
        Task<IList<SolutionFeedback>> GetAllFeedbacks(int solutionId);

        Task<IList<SolutionFeedback>> GetFeedbacksByEmployee(int  employeeId);

    }
}
