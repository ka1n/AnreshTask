using AnreshTaskWeb.Models;
using System.Collections.Generic;

namespace AnreshTaskWeb.Repository
{
    public interface IPersonRepository<T> where T : Person
    {
        void Add(T item);
        void Remove(int id);
        void Update(T item);
        T FindByID(int id);
        IEnumerable<T> FindAll();
    }
}