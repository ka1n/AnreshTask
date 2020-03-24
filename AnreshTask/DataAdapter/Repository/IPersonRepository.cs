using DataAdapter.Models;
using DataAdapter.Interface;
using System.Collections.Generic;

namespace DataAdapter.Repository
{
    public interface IPersonRepository : IRepositoryBase
    {
        void Add(Person item);
        void Remove(int id);
        void Update(Person item);
        Person FindByID(int id);
        List<Person> FindAll();
    }
}