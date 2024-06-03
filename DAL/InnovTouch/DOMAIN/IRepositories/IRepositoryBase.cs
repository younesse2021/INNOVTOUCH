using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InnovTouch.DAL.DOMAIN.IRepositories
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> All();
        Task<List<T>> AllAsync();
        IQueryable<T> AllIgnoreQueryFilters();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<List<T>> WhereAsync(Expression<Func<T, bool>> expression);
        Task<T> WhereFirstAsync(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void CreateRange(List<T> entity);
        Task<T> CreateAsync(T entity);
        Task CreateRangeAsync(List<T> entities);
        bool Update(T entity);
        void Delete(T entity);
        void DeleteRange(List<T> entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        
    }
}
