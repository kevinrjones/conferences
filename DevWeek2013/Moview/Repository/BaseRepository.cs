using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BaseRepository<T> : IRepository<T> where T : new()
    {
        public void Dispose()
        {

        }

        protected readonly List<T> _database;
        public BaseRepository()
        {
            _database = new List<T>();
        }

        public IQueryable<T> Entities { get { return _database.AsQueryable(); }  }
        public T New()
        {
            return new T();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public T Create(T entity)
        {
            _database.Add(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
