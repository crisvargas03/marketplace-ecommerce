using marketplaceAPI.DAL.Context;
using marketplaceAPI.DAL.Models;
using marketplaceAPI.DAL.Repository.Core;
using marketplaceAPI.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace marketplaceAPI.DAL.Repository
{
    public class UserRepository : BaseRepository<User>, IUserInterface
    {
        public UserRepository(MainDbContext context) : base(context)
        {
        }
    }
}
