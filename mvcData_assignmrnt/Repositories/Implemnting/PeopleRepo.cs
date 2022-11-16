using mvcData_assignmrnt.Models;
using mvcData_assignmrnt.Data;
using System.Data;
using System.Data.SQLite;
using Dapper;

namespace mvcData_assignmrnt.Repositories.Implemting
{
    public class PeopleRepo : IPeopleRepo
    {
        private readonly MemoryData _data;
        private static string connectionString = "Data Source=Data/data.db";
        public PeopleRepo()
        {
            _data = new MemoryData();
        }

        public Person AddPerson(Person person)
        {
            List<Person> result;
            using (IDbConnection conn = new SQLiteConnection(connectionString))
            {

                var addedPerson = conn.Query<Person>(@"INSERT INTO People (Name,PhoneNumber,City) VALUES (@Name,@PhoneNumber,@City);
                                                        SELECT * FROM People WHERE Id = (SELECT MAX(Id) FROM People);", person);

                result = addedPerson.ToList();
            }

            if (!result.Any())
            {
                throw new Exception("Field to add person");
            }

            return result.FirstOrDefault()!;
        }

        public bool Delete(Person person)
        {
           bool result = false;
            using (IDbConnection conn = new SQLiteConnection(connectionString))
            {
                result = conn.Execute("DELETE FROM People WHERE Id = @Id", person) > 0;
            }
            return result;
        }

        public Person? ReadById(int id)
        {
            Person? person;
            using (IDbConnection conn = new SQLiteConnection(connectionString))
            {
                var result = conn.Query<Person>($"SELECT * FROM People WHERE Id = {id}");

                person= result.FirstOrDefault();
            }

            return person;
        }

        public List<Person> Read()
        {
            List<Person> people = new List<Person>();
            using (IDbConnection conn =new SQLiteConnection(connectionString))
            {
                var peopleQuery = conn.Query<Person>("SELECT * FROM People");

                people = peopleQuery.ToList();
            }

            return people;
        }

        public bool Update(Person person)
        {
            bool result = false;
            using (IDbConnection conn = new SQLiteConnection(connectionString))
            {
                result = conn.Execute("UPDATE People SET Name=@Name, PhoneNumber=@Number, City=@City WHERE Id = @Id", person) > 0;
            }

            return result;
        }
    }
}
