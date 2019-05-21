using MovieDatabase.Repository.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabase.Repository.Interfaces
{

    public interface IBaseRepository<T> : IDisposable
    {
        T Add(T entity);

        void Update(T entity);

        void Delete(int id);

        T Get(int id);

        IQueryable<T> GetAll();

        void Save();
    }
}
