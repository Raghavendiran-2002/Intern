using CodeFirstApproach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public interface IRequestRepository : IRepository<int, Request>
    {
        public Task<List<Request>> GetByEmployeeId(int key);

    }
}
