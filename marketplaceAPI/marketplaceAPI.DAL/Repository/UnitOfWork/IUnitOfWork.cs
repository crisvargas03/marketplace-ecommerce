using marketplaceAPI.DAL.Repository.Interfaces;

namespace marketplaceAPI.DAL.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserInterface Users { get; }
        Task CompleteAsync();
    }
}
