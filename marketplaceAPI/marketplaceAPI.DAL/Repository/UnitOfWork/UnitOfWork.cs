using marketplaceAPI.DAL.Context;
using marketplaceAPI.DAL.Repository.Interfaces;

namespace marketplaceAPI.DAL.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MainDbContext _context;

        public IUserInterface Users { get; private set; }

        public UnitOfWork(MainDbContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
