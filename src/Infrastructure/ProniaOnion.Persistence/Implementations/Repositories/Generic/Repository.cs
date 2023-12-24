using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Domain.Entities;
using ProniaOnion.Persistence.Contexts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ProniaOnion.Persistence.Implementations.Repositories;

    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly DbSet<T> _table;
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _table = context.Set<T>();
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _table.AddAsync(entity);
        }

        public Task<IQueryable<Category>> GetAllAsync(Expression<Func<Category, bool>>? expression = null, params string[] includes)
        {
            throw new NotImplementedException();
        }


        public async Task SaveChangesAsync(T entity)
        {
            await _context.SaveChangesAsync();
        }
        public IQueryable<T> GetAll(bool isTracking = true, bool ignoreQuery = false, params string[] includes)
        {
        IQueryable<T> query = _table;
        query=_addIncludes(query, includes);

        if (ignoreQuery) query = query.IgnoreQueryFilters();
        return isTracking ? query : query.AsNoTracking();
        }

        public IQueryable<T> GetAllWhere(Expression<Func<T, bool>>? expression = null, Expression<Func<T, object>>? orderExpression = null, bool isDescending = false, int skip = 0, int take = 0, bool isTracking = true, bool ignoreQuery = false, params string[] includes)
        {
        var query = _table.AsQueryable();
        if (expression != null)
        {
            query = query.Where(expression);
        }
        if (orderExpression != null)
        {
            if (isDescending)
            {
                query = query.OrderByDescending(orderExpression);
            }
            else
            {
                query = query.OrderBy(orderExpression);
            }
        }
        if (skip != 0)
        {
            query = query.Skip(skip);
        }
        if (take != 0)
        {
            query = query.Take(take);
        }

        query = _addIncludes(query,includes);

        if (ignoreQuery) query = query.IgnoreQueryFilters();

        return isTracking ? query : query.AsNoTracking();
        }

        public async Task<T> GetByIdAsync(int id, bool isTracking = true, bool ignoreQuery = false, params string[] includes)
        {
        IQueryable<T> query = _table.Where(x=>x.Id==id);

        query = _addIncludes(query, includes);

        if (!isTracking) query = query.AsNoTracking();
        if(ignoreQuery) query = query.IgnoreQueryFilters();
        return await query.FirstOrDefaultAsync();
        }

        public async Task<T> GetByExpressionAsync(Expression<Func<T, bool>> expresson, bool isTracking = true, bool ignoreQuery = false, params string[] includes)
        {
        IQueryable<T> query = _table.Where(expresson);
        if (includes != null)
        {
            for (int i = 0; i < includes.Length; i++)
            {
                query = query.Include(includes[i]);
            }
        }
        if (!isTracking) query = query.AsNoTracking();
        if (ignoreQuery) query = query.IgnoreQueryFilters();
        return await query.FirstOrDefaultAsync();
    }

        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression, bool ignoreQuery = false)
        {
        return ignoreQuery ? await _table.AnyAsync(expression):await _table.IgnoreQueryFilters().AnyAsync(expression);
        }

        public void Update(T entity)
        {
        _table.Update(entity);
        }
        public void Delete(T entity)
        {
        _table.Remove(entity);
        }

        public void SoftDelete(T entity)
        {
        entity.IsDeleted = true;
        }
        public void ReverseSoftDelete(T entity)
        {
        entity.IsDeleted = false;
        }
        public Task SaveChangesAsync()
        {
        throw new NotImplementedException();
        }

    private IQueryable<T> _addIncludes(IQueryable<T> query, params string[] includes)
    {
        if (includes != null)
        {
            for(int i = 0; i < includes.Length; i++)
            {
                query= query.Include(includes[i]);
            }
        }
        return query;
    }


    }
