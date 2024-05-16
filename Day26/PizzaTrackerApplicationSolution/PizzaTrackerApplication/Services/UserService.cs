using PizzaTrackerApi.Models;
using PizzaTrackerApplication.Exceptions;
using PizzaTrackerApplication.Interfaces;
using PizzaTrackerApplication.Models.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace PizzaTrackerApplication.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<int, User> _userRepo;
        private readonly ITokenService _tokenService;

        public UserService(IRepository<int, User> userRepo, ITokenService tokenService)
        {
            _userRepo = userRepo;
            _tokenService = tokenService;
        }
        public async Task<LoginReturnDTO> Login(UserLoginDTO loginDTO)
        {
            var userDB = await _userRepo.Get(loginDTO.UserId);
            if (userDB == null)
            {
                throw new UnauthorizedUserException("Invalid username or password");
            }
            HMACSHA512 hMACSHA = new HMACSHA512(userDB.PasswordHashKey);
            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
            bool isPasswordSame = ComparePassword(encrypterPass, userDB.Password);
            if (isPasswordSame)
            {
                var user = await _userRepo.Get(loginDTO.UserId);
                LoginReturnDTO loginReturnDTO = MapUserToLoginReturn(user);
                return loginReturnDTO;
            }
            throw new UnauthorizedUserException("Invalid username or password");
        }

        private LoginReturnDTO MapUserToLoginReturn(User user)
        {
            LoginReturnDTO returnDTO = new LoginReturnDTO();
            returnDTO.EmployeeID = user.UserId;
         
            returnDTO.Token = _tokenService.GenerateToken(user);
            return returnDTO;
        }

        private bool ComparePassword(byte[] encrypterPass, byte[] password)
        {
            for (int i = 0; i < encrypterPass.Length; i++)
            {
                if (encrypterPass[i] != password[i])
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<SuccessfullRegisterDTO> Register(UserRegisterDTO registerDTO)
        {
            User user = null;
            SuccessfullRegisterDTO successfullRegisterDTO = null;
            try
            {
                user = MapEmployeeUserDTOToUser(registerDTO);
                await _userRepo.Add(user);
                successfullRegisterDTO  = new SuccessfullRegisterDTO() { UserId = user.UserId, UserName = user.Username };
                return successfullRegisterDTO;
            }
            catch (Exception) { }
            return successfullRegisterDTO;
        }

        private User MapEmployeeUserDTOToUser(UserRegisterDTO registerDTO)
        {
            User user = new User();
            HMACSHA512 hMACSHA = new HMACSHA512();
            user.Username = registerDTO.UserName;
            user.PasswordHashKey = hMACSHA.Key;
            user.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password));
            return user;
        }
    }
}
