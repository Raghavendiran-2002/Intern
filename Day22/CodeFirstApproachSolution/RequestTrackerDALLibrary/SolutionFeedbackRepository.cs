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
    public class SolutionFeedbackRepository : ISolutionFeedbackRepository
    {
        private readonly RequestTrackerContext _context;
        public SolutionFeedbackRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<SolutionFeedback> Add(SolutionFeedback entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<SolutionFeedback> Delete(int key)
        {
            var solutionFeedback = await Get(key);
            if (solutionFeedback != null)
            {
                _context.Feedbacks.Remove(solutionFeedback);
                _context.SaveChanges();
            }
            return solutionFeedback;
        }

        public async Task<SolutionFeedback> Get(int key)
        {
            var solutionFeedback = await _context.Feedbacks.SingleOrDefaultAsync(e => e.FeedbackId == key);
            return solutionFeedback;
        }

        public async Task<List<SolutionFeedback>> GetAll()
        {
            return await _context.Feedbacks.ToListAsync();

        }

        public async Task<SolutionFeedback> Update(SolutionFeedback entity)
        {
            var solutionFeedback = await Get(entity.SolutionId);
            if (solutionFeedback != null)
            {
                _context.Entry<SolutionFeedback>(solutionFeedback).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return solutionFeedback;
        }

        public async Task<List<SolutionFeedback>> GetFeedbackByEmployeeId(int id)
        {
            var solutionFeedback = await _context.Feedbacks.Where(e => e.FeedbackByEmployee == (_context.Employees.SingleOrDefault(em => em.Id == id))).ToListAsync();
            if(solutionFeedback == null) { }
            return solutionFeedback;
        }
    }
}
