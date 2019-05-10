using ApplicationCore.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieDbContext _context;
        private Dictionary<string, object> _repositories;
        public UnitOfWork(MovieDbContext context)
        {
            _context = context;
        }
        public IGenericRepository<TEntity> GenericRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, object>();
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }
            return (IGenericRepository<TEntity>)_repositories[type];
        }

        public void SaveAsync()
        {
            _context.SaveChanges();
        }

        public void WriteLog(string text)
        {
            throw new NotImplementedException();
        }

    }
}
