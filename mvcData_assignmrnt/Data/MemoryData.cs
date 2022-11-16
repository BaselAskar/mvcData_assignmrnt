using mvcData_assignmrnt.Models;
using System.Data;
using System.Data.SQLite;

namespace mvcData_assignmrnt.Data
{
    public class MemoryData
    {
        private static int currentPersonId = 0;

        public static int NextPersonId => ++currentPersonId;

        private static string connectionString = "Data Source= Data/data.db;";


        private static readonly List<string> cities = new List<string>
        {
            "Malmö","Växjö","Jönköping","Stockholm","Götoburg"
        };


        private static List<Person> people= new List<Person>();

        public static List<string> Cities => cities;

        public List<Person> People { get => people; set => people = value; }

        
    }
}
