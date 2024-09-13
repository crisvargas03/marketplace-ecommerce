using marketplaceAPI.DAL.Utils;
using System.Linq.Expressions;

namespace marketplaceAPI.DAL.Repository.Core
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(PaginationArguments paginationArguments,
            bool tracked = true,
            Expression<Func<T, bool>>? whereExpression = null,
            Expression<Func<T, object>>? includeExpression = null,
            Expression<Func<T, object>>? orderExpression = null);
        Task<T> GetAsync(bool tracked = true,
            Expression<Func<T, bool>>? whereExpression = null);
        Task<bool> ExitsAsync(Expression<Func<T, bool>> whereExpression);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
