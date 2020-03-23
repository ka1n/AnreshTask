using AnreshTaskWeb.Models;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AnreshTaskWeb.Repository
{
    public class PersonRepository : IPersonRepository<Person>
    {
        private readonly string connectionString;

        public PersonRepository()
        {
            connectionString = "User ID=a.kirillov;Password=qweqwe123;Host=localhost;Port=5432;Database=anresh;Pooling=true;";
        }

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }

        public void Add(Person item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();

                dbConnection.Execute("INSERT INTO anresh.person (last_name, first_name ,patronymic,age) VALUES(@LastName,@FirstName,@Patronymic, @Age) ", item);
            }
        }

        public IEnumerable<Person> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Person>("SELECT id as Id, last_name as \"LastName\",first_name as \"FirstName\",patronymic,age FROM anresh.person");
            }
        }

        public Person FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Person>("SELECT * FROM anresh.person WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM anresh.person WHERE id=@Id", new { Id = id });
            }
        }

        public void Update(Person item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE anresh.person SET last_name = @LastName,  first_name  = @FirstName, patronymic= @Patronymic, age = @Age WHERE id = @Id", item);
            }
        }
    }
}