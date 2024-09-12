using marketplaceAPI.DAL.Context;
using marketplaceAPI.DAL.Models;
using marketplaceAPI.DAL.Repository.Core;
using marketplaceAPI.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace marketplaceAPI.DAL.Repository
{
    public class UserRepository(MainDbContext context, DbSet<User> dbSet) :
        BaseRepository<User>(context, dbSet), IUserInterface
    {
    }
}
