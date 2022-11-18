using mvcData_assignmrnt.Data;

namespace mvcData_assignmrnt.Models
{
    public class Person
    {

        public int Id { get; init; } = MemoryData.NextPersonId;
        public string? Name { get; set; }
        public int PhoneNumber { get; set; }
        public string? City { get; set; }

    }
}
