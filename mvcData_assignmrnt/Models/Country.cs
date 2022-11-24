using System.ComponentModel.DataAnnotations;

namespace mvcData_assignmrnt.Models
{
    public class Country
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name of country is required ....!")]
        public string? Name { get; set; }
        public List<City> Cities { get; set; } = new List<City>();
    }
}
