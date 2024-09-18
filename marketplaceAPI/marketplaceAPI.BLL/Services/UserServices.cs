using AutoMapper;
using marketplaceAPI.BLL.DTOs.AuthModels;
using marketplaceAPI.BLL.DTOs.UtilsModels;
using marketplaceAPI.BLL.Interfaces;
using marketplaceAPI.DAL.Models;
using marketplaceAPI.DAL.Repository.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace marketplaceAPI.BLL.Services
{
    public class UserServices : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;
        private readonly APIResponse _response = new APIResponse();

        public UserServices(IUnitOfWork unitOfWork, IJwtService jwtService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
            _mapper = mapper;
        }

        public async Task<APIResponse> Login(UserLoginWithCredsDto userLogin)
        {
            try
            {
                var dbUser = await _unitOfWork.Users.GetAsync(
                    whereExpression: x => x.Email == userLogin.Email, 
                    tracked: false);

                var validationResponse = ValidateUserLogin(userLogin, dbUser);
                if (validationResponse != null) return validationResponse;

                var token = _jwtService.GenerateToken(GetUserDTOFromDbUser(dbUser));
                var isAdmin = IsAdmin(dbUser.RoleId);
                var payload = new { dbUser.Name, dbUser.Email, dbUser.Id, isAdmin, token };
                return _response.SuccesResponse(HttpStatusCode.OK, payload);
            }
            catch (Exception)
            {
                return _response.FailedResponse(HttpStatusCode.InternalServerError, "Failded to process the request, try again later.");
            }
        }

        public async Task<APIResponse> Register(UserRegisterWithCredsDto userRegister)
        {
            try
            {
                var validationResponse = ValidateUserRegistration(userRegister);
                if (validationResponse != null) return validationResponse;

                var userExits = await _unitOfWork.Users.ExitsAsync(x => x.Email == userRegister.Email);
                if (userExits)
                    return _response.FailedResponse(HttpStatusCode.BadRequest, "Email already used");

                var userToCreate = CreateUser(userRegister);
                await _unitOfWork.Users.CreateAsync(userToCreate);
                await _unitOfWork.CompleteAsync();

                var token = _jwtService.GenerateToken(GetUserDTOFromDbUser(userToCreate));
                var isAdmin = IsAdmin(userToCreate.RoleId);
                var payload = new { userToCreate.Name, userToCreate.Email, userToCreate.Id, isAdmin, token };
                return _response.SuccesResponse(HttpStatusCode.OK, payload);
            }
            catch (Exception)
            {
                return _response.FailedResponse(HttpStatusCode.InternalServerError, "Failded to process the request, try again later.");
            }
        }

        public async Task<APIResponse> RenewToken(Guid userId)
        {
            try
            {
                var dbUser = await _unitOfWork.Users.GetAsync(
                    whereExpression: x => x.Id == userId,
                    tracked: false);

                if (dbUser is null)
                    return _response.FailedResponse(HttpStatusCode.BadRequest, "User not found");

                var token = _jwtService.GenerateToken(GetUserDTOFromDbUser(dbUser));
                var isAdmin = IsAdmin(dbUser.RoleId);
                var payload = new { dbUser.Name, dbUser.Email, dbUser.Id, isAdmin, token };
                return _response.SuccesResponse(HttpStatusCode.OK, payload);
            }
            catch (Exception)
            {
                return _response.FailedResponse(HttpStatusCode.InternalServerError, "Failded to process the request, try again later.");
            }
        }

        private UserDTO GetUserDTOFromDbUser(User user) => _mapper.Map<UserDTO>(user);
        private static bool IsAdmin(int roleId) => roleId == 200;
        private User CreateUser (UserRegisterWithCredsDto userRegister)
        {
            var user = _mapper.Map<User>(userRegister);
            user.Id = Guid.NewGuid();
            user.Password = Bcrypt.EnhancedHashPassword(userRegister.Password, 8);
            user.UserName = userRegister.Email;
            user.RoleId = 200; // client: 200, admin: 900
            return user;
        }

        private APIResponse? ValidateUserRegistration(UserRegisterWithCredsDto userRegister)
        {
            if (string.IsNullOrWhiteSpace(userRegister.Password) || userRegister.Password.Length < 6)
                return _response.FailedResponse(HttpStatusCode.BadRequest, "Password too short");
            if (string.IsNullOrWhiteSpace(userRegister.Email))
                return _response.FailedResponse(HttpStatusCode.BadRequest, "Email is required");
            return null;
        }

        private APIResponse? ValidateUserLogin(UserLoginWithCredsDto userLogin, User userFromDb)
        {
            if (userFromDb is null)
                return _response.FailedResponse(HttpStatusCode.BadRequest, "Email or Password incorrect");
            
            var passwordMatch = Bcrypt.EnhancedVerify(userLogin.Password, userFromDb.Password);
            if (!passwordMatch)
                return _response.FailedResponse(HttpStatusCode.BadRequest, "Email or Password incorrect");
            return null;
        }
    }
}
