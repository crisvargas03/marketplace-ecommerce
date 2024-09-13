using marketplaceAPI.BLL.Interfaces;
using marketplaceAPI.DAL.Repository.UnitOfWork;
using marketplaceAPI.DAL.Utils;

namespace marketplaceAPI.BLL.Services
{
    public class UserServices : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<object> Test()
        {
            var page = new PaginationArguments();
            var resutl = await _unitOfWork.Users.GetAllAsync(page);

            return resutl;
        }
    }
}
