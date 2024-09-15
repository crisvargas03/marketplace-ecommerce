using marketplaceAPI.BLL.DTOs.AuthModels;

namespace marketplaceAPI.BLL.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(UserDTO user);
    }
}
