using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(object id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(object id);
    }
}
