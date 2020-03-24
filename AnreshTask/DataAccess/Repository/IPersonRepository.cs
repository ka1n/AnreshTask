using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public interface IPersonRepository
    {
        void Add(Person item);
        void Remove(int id);
        void Update(Person item);
        Person FindByID(int id);
        List<Person> FindAll();
    }
}