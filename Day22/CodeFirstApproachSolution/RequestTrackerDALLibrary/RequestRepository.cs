using CodeFirstApproach;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class RequestRepository : IRequestRepository
    {
        private readonly RequestTrackerContext _context;
        public RequestRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Request> Add(Request entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task <List<Request>> GetByEmployeeId(int key)
        {
            var requests = await _context.Requests.Where(e => e.RaisedByEmployee == (_context.Employees.SingleOrDefault(ep => ep.Id == key))).ToListAsync();
            if(requests == null)
            { }
            return requests;
        }
       

        public async Task<Request> Delete(int key)
        {
            var request = await Get(key);
            if(request != null)
            {
                _context.Requests.Remove(request);
                _context.SaveChanges();
            }
            return request;
        }

        public async Task<Request> Get(int key)
        {
            var request = _context.Requests.SingleOrDefault(r => r.RequestNumber == key);
            return request;
        }

        public async Task<List<Request>> GetAll()
        {
            return await _context.Requests.ToListAsync();
        }
        public async Task<List<Request>> GetRequestByEmployee(Employee employee)
        {
            return await _context.Requests.Where(r=>r.RaisedByEmployee == employee).ToListAsync();
        }
        public async Task<Request> Update(Request entity)
        {
            var request = await Get(entity.RequestNumber);
            if(request != null)
            {
                _context.Entry<Request>(request).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return request;
        }
    }
}
