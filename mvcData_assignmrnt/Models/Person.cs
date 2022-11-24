using mvcData_assignmrnt.Data;
using System.ComponentModel.DataAnnotations;

namespace mvcData_assignmrnt.Models
{
    public class Person
    {

        public int Id { get; init; }
        public string? Name { get; set; }
        public int PhoneNumber { get; set; }

        [Required]
        public City? City { get; set; }

    }
}
