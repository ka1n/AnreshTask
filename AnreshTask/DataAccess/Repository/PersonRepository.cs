using Dapper;
using DataAccess.Models;
using Npgsql;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;

namespace DataAccess.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly string connectionString;
        public PersonRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings[1].ToString();
        }

        //private IDbConnection Connection
        //{
        //    get
        //    {
        //        return new 
        //    }
        //}

        public void Add(Person item)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(connectionString))
            {
                dbConnection.Open();

                dbConnection.Execute("INSERT INTO anresh.person (last_name, first_name ,patronymic,age) VALUES(@LastName,@FirstName,@Patronymic, @Age) ", item);
            }
        }

        public List<Person> FindAll()
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(connectionString))
            {
                dbConnection.Open();
                return dbConnection.Query<Person>("SELECT id as Id, last_name as \"LastName\",first_name as \"FirstName\",patronymic,age FROM anresh.person").ToList();
            }
        }

        public Person FindByID(int id)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(connectionString))
            {
                dbConnection.Open();
                return dbConnection.Query<Person>("SELECT id as Id, last_name as \"LastName\",first_name as \"FirstName\",patronymic,age FROM anresh.person WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(connectionString))
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM anresh.person WHERE id=@Id", new { Id = id });
            }
        }

        public void Update(Person item)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(connectionString))
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE anresh.person SET last_name = @LastName,  first_name  = @FirstName, patronymic= @Patronymic, age = @Age WHERE id = @Id", item);
            }
        }

        #region IDisposable

        public bool CanDispose { get; set; }

        public void Dispose(bool force)
        {
            this.CanDispose = true;
            Dispose();
        }

        public void Dispose()
        {
            //if (Connection != null && this.CanDispose)
            //    Connection.Dispose();
        }
        #endregion 
    }
}