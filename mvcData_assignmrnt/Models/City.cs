using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace mvcData_assignmrnt.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name of city is required..!")]
        public string? Name { get; set; }

        [Required]
        public Country? Country { get; set; }
        public List<Person>? Persons { get; set; }

    }
}
