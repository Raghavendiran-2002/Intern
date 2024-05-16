using PizzaTrackerApi.Models;

namespace PizzaTrackerApplication.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
