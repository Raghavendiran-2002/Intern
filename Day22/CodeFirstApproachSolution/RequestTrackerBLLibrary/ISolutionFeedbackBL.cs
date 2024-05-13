using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface ISolutionFeedbackBL
    {
        public Task<SolutionFeedback> GiveFeedback(SolutionFeedback solutionfeedback);
        
        public Task<List<SolutionFeedback>> GetFeedbackByAdmin(int  adminId);
    }
}
