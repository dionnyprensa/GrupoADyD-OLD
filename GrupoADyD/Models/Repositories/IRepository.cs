using System.Collections.Generic;

namespace GrupoADyD.Models.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> List { get; }
        void Add(T entity);
        void Delete(int Id);
        void Update(T entity);
        T FindById(int Id);
    }
}