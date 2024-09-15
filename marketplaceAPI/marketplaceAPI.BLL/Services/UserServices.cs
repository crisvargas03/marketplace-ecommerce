using marketplaceAPI.BLL.Interfaces;
using marketplaceAPI.DAL.Repository.UnitOfWork;

namespace marketplaceAPI.BLL.Services
{
    public class UserServices : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;

        public UserServices(IUnitOfWork unitOfWork, IJwtService jwtService)
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
        }
    }
}
