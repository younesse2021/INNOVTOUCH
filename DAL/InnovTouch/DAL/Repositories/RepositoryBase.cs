using DAL.InnovTouch.DAL;
using DAL.InnovTouch.DAL.DOMAIN.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ma.Marjane.RPC.DAL.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected InnovTouchDbContext RepositoryContext { get; set; }
        protected RepositoryBase(InnovTouchDbContext repositoryContext) => RepositoryContext = repositoryContext;
        public IQueryable<T> All() => RepositoryContext.Set<T>().AsNoTracking();
        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression) => await RepositoryContext.Set<T>().AnyAsync(expression);
        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);
        public void CreateRange(List<T> entities) => RepositoryContext.Set<T>().AddRange(entities);
        public bool Update(T entity)
        {
            var Ent = RepositoryContext.Entry(entity);
            int Id = (int)Ent.CurrentValues["Id"];

            var expression = $"(ent.Id == {Id})";
            var param = Expression.Parameter(typeof(T), "ent");

            LambdaExpression e = DynamicExpressionParser.ParseLambda(new[] { param }, null, expression);
            var entityFound = RepositoryContext.Set<T>().Where(e).FirstOrDefault();

            if (entityFound == null) { return false; }
            RepositoryContext.Entry(entityFound).State = EntityState.Detached;

            var updated = RepositoryContext.Set<T>().Update(entity);
            if(updated.State != EntityState.Modified)
            {
                return false;
            }
            return true;
        }

        public void DeleteById(int Id)
        {
            var expression = $"(ent.Id == {Id})";
            var param = Expression.Parameter(typeof(T), "ent");

            LambdaExpression e = DynamicExpressionParser.ParseLambda(new[] { param }, null, expression);
            var entity = RepositoryContext.Set<T>().Where(e).FirstOrDefault();

            if (entity == null) { return; }
            RepositoryContext.Set<T>().Remove(entity);
        }
        public void Delete(T entity)
        {
            var Ent = RepositoryContext.Entry(entity);
            int Id = (int)Ent.CurrentValues["Id"];
            DeleteById(Id);
        }
        public void DeleteRange(List<T> entities) => RepositoryContext.Set<T>().RemoveRange(entities);
        public async Task<T> CreateAsync(T entity)
        {
            var entit = await RepositoryContext.Set<T>().AddAsync(entity);
            return entit.Entity;
        }
        public async Task CreateRangeAsync(List<T> entities) => await RepositoryContext.Set<T>().AddRangeAsync(entities);
        public async Task<List<T>> AllAsync()
        {
            return await All().ToListAsync();
        }
        public async Task<List<T>> WhereAsync(Expression<Func<T, bool>> expression)
        {
            return await Where(expression).ToListAsync();
        }
        public async Task<T> WhereFirstAsync(Expression<Func<T, bool>> expression)
        {
            return await Where(expression).FirstOrDefaultAsync();
        }

        public IQueryable<T> AllIgnoreQueryFilters() => RepositoryContext.Set<T>().IgnoreQueryFilters().AsNoTracking();
    }
}
