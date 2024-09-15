
using marketplaceAPI.BLL.DTOs.AuthModels;
using marketplaceAPI.BLL.DTOs.UtilsModels;

namespace marketplaceAPI.BLL.Interfaces
{
    public interface IUserService
    {
        Task<APIResponse> Login(UserLoginWithCredsDto userLogin);
        Task<APIResponse> Register(UserRegisterWithCredsDto userRegister);
    }
}
