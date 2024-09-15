using AutoMapper;
using marketplaceAPI.BLL.DTOs.AuthModels;
using marketplaceAPI.BLL.DTOs.UtilsModels;
using marketplaceAPI.BLL.Interfaces;
using marketplaceAPI.DAL.Models;
using marketplaceAPI.DAL.Repository.UnitOfWork;
using System.Net;

namespace marketplaceAPI.BLL.Services
{
    public class UserServices : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public UserServices(IUnitOfWork unitOfWork, IJwtService jwtService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
            _response = new();
            _mapper = mapper;
        }

        public async Task<APIResponse> Login(UserLoginWithCredsDto userLogin)
        {
            try
            {
                var dbUser = await _unitOfWork.Users.GetAsync(
                    whereExpression: x => x.Email == userLogin.Email, 
                    tracked: false);

                if (dbUser is null)
                    return _response.FailedResponse(HttpStatusCode.BadRequest, "Email or Password incorrect");

                var passwordMatch = Bcrypt.EnhancedVerify(userLogin.Password, dbUser.Password);
                if (!passwordMatch)
                    return _response.FailedResponse(HttpStatusCode.BadRequest, "Email or Password incorrect");

                var mappedUserDto = _mapper.Map<UserDTO>(dbUser);
                var token = _jwtService.GenerateToken(mappedUserDto);
                var isAdmin = dbUser.RoleId == 3003;
                _response.Payload = new { dbUser.Name, dbUser.Email, dbUser.Id, isAdmin, token };
                return _response;
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
                if (userRegister.Password.Length < 6)
                    return _response.FailedResponse(HttpStatusCode.BadRequest, "Passwor too short");
                
                var userExits = await _unitOfWork.Users.ExitsAsync(x => x.Email == userRegister.Email);
                if (userExits)
                    return _response.FailedResponse(HttpStatusCode.BadRequest, "Email already used");

                var userToCreate = _mapper.Map<User>(userRegister);
                userToCreate.Id = Guid.NewGuid();
                userToCreate.Password = Bcrypt.EnhancedHashPassword(userRegister.Password, 8);
                userToCreate.UserName = userRegister.Email;
                userToCreate.RoleId = 200; // client: 200, admin: 900

                await _unitOfWork.Users.CreateAsync(userToCreate);
                await _unitOfWork.CompleteAsync();

                var userDto = _mapper.Map<UserDTO>(userToCreate);
                var token = _jwtService.GenerateToken(userDto);
                var isAdmin = userToCreate.RoleId == 3003;
                _response.Payload = new { userToCreate.Name, userToCreate.Email, userToCreate.Id, isAdmin, token };
                return _response;
            }
            catch (Exception)
            {
                return _response.FailedResponse(HttpStatusCode.InternalServerError, "Failded to process the request, try again later.");
            }
        }
    }
}
