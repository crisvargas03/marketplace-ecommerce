﻿using marketplaceAPI.DAL.Context;
using marketplaceAPI.DAL.Models;
using marketplaceAPI.DAL.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace marketplaceAPI.DAL.Repository.Core
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly MainDbContext _context;
        private DbSet<T> _dbSet;
        public BaseRepository(MainDbContext context, DbSet<T> dbSet)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<List<T>> GetAllAsync(PaginationArguments paginationArguments, bool tracked = true, Expression<Func<T, bool>>? whereExpression = null, Expression<Func<T, object>>? includeExpression = null, Expression<Func<T, object>>? orderExpression = null)
        {
            IQueryable<T> query = _context.Set<T>().AsQueryable();
            if (whereExpression != null)
            {
                query = query.Where(whereExpression);
            }
            if (includeExpression != null)
            {
                query = query.Include(includeExpression);
            }
            if (orderExpression != null)
            {
                query = query.OrderByDescending(orderExpression);
            }
            if (paginationArguments.PageSize > 0)
            {
                if (paginationArguments.PageSize > 100) paginationArguments.PageSize = 100;
                query = query.Skip(paginationArguments.PageSize * (paginationArguments.PageNumber - 1)).Take(paginationArguments.PageSize);
            }
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            return await query.ToListAsync();
        }

        public virtual async Task<T> GetAsync(bool tracked = true, Expression<Func<T, bool>>? whereExpression = null)
        {
            IQueryable<T> query = _context.Set<T>().AsQueryable();
            if (whereExpression != null)
            {
                query = query.Where(whereExpression);
            }
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task CreateAsync(T entity)
        {
            try
            {
                await _context.AddAsync(entity);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new DataLayerException($"FAILDED at Create {entity.GetType()} - {ex.Message}");
            }
        }

        public virtual async Task<bool> ExitsAsync(Expression<Func<T, bool>> whereExpression)
        {
            try
            {
                return await _dbSet.AnyAsync(whereExpression);
            }
            catch (Exception ex)
            {
                throw new DataLayerException($"FAILDED at Exits - {ex.Message}");
            }
        }

        public virtual async Task DeleteAsync(T entity)
        {
            try
            {
                _context.Update(entity);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new DataLayerException($"FAILDED at Delete {entity.GetType()} - {ex.Message}");
            }
        }

        public virtual async Task UpdateAsync(T entity)
        {
            try
            {
                _context.Update(entity);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new DataLayerException($"FAILDED at Update {entity.GetType()} - {ex.Message}");
            }
        }

        public virtual async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
