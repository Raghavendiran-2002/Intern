using Microsoft.EntityFrameworkCore;
using PizzaTrackerApi.Context;
using PizzaTrackerApi.Models;
using PizzaTrackerApplication.Interfaces;

namespace PizzaTrackerApplication.Models.Repositories
{
    public class UserRepository : IRepository<int, User>
    {
        private readonly PizzaTrackerContext _context;

        public UserRepository(PizzaTrackerContext context)
        {
            _context = context;            
        }
        public async Task<User> Add(User item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<User> Delete(int key)
        {
            var user = await Get(key);
            if (user != null)
            {
                _context.Remove(user);
                await _context.SaveChangesAsync(true);
                return user;
            }
            throw new NotImplementedException();
        }

        public async Task<User> Get(int key)
        {
            var user = await _context.Users.FirstOrDefaultAsync(e => e.UserId == key);
            return user;
        }

        public async Task<IEnumerable<User>> Get()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User> Update(User item)
        {
            var user = await Get(item.UserId);
            if (user != null)
            {
                _context.Update(user);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new NotImplementedException();
        }
    }
}
