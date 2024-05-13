using CodeFirstApproach;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public interface ISolutionFeedbackRepository : IRepository<int, SolutionFeedback>
    {
        public Task<List<SolutionFeedback>> GetFeedbackByEmployeeId(int id);
    }
}

