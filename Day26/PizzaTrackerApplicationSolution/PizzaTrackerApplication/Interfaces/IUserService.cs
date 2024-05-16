using PizzaTrackerApi.Models;
using PizzaTrackerApplication.Models.DTOs;

namespace PizzaTrackerApplication.Interfaces
{
    public interface IUserService
    {
        public Task<LoginReturnDTO> Login(UserLoginDTO loginDTO);
        public Task<SuccessfullRegisterDTO> Register(UserRegisterDTO registerDTO);
    }
}
