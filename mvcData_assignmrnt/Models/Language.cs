using System.ComponentModel.DataAnnotations;

namespace mvcData_assignmrnt.Models
{
    public class Language
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public List<Person> People { get; set; } = new List<Person>();

    }
}
