using mvcData_assignmrnt.Models;
using System.Text.Json;

namespace mvcData_assignmrnt.Data
{
    public class MemoryData
    {
        private static int currentPersonId = 0;

        private static string path = "Data/peopleData.json";

        private static string counterPath = "Data/counterData.json";

        public static int NextPersonId
        {
            get
            {
                string counterData;
                try
                {
                    counterData = File.ReadAllText(counterPath);

                    IdCounter? idCounter = JsonSerializer.Deserialize<IdCounter>(counterData);

                    int nextId = ++idCounter!.CurrentId;

                    string json = JsonSerializer.Serialize(idCounter);

                    File.WriteAllText(counterPath,json);

                    return nextId;

                }
                catch (IOException ex)
                {
                    IdCounter idCounter = new IdCounter { CurrentId = 1 };

                    string json = JsonSerializer.Serialize(idCounter);

                    File.WriteAllText(counterPath,json);

                    return idCounter.CurrentId;
                }
            }
        }


        private static readonly List<string> cities = new List<string>
        {
            "Malmö","Växjö","Jönköping","Stockholm","Götoburg"
        };


        private static List<Person> people= new List<Person>();

        public static List<string> Cities => cities;

        public List<Person> People { get => people; set => people = value; }


        public List<Person> PeopleContext
        {
            get
            {

                string jsonData;
                try
                {
                    jsonData = File.ReadAllText(path);


                    List<Person> people = JsonSerializer.Deserialize<List<Person>>(jsonData)!;

                    return people;
                }
                catch (IOException ex)
                {
                    List<Person> people = new List<Person>();

                    jsonData = JsonSerializer.Serialize(people);

                    File.WriteAllText(path, jsonData);

                    return new List<Person>();
                }

            }
            set
            {
                string json = JsonSerializer.Serialize(value);

                File.WriteAllText(path,json);
            }
        }

    }
}
