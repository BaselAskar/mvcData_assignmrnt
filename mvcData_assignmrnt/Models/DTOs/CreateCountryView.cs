
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace mvcData_assignmrnt.Models.DTOs
{
    public class CreateCountryView
    {
        [Required(ErrorMessage = "The name of country is required...!")]
        [Display(Name = "Name")]
        [BindProperty]
        public string? Name { get; set; }

        [Required]
        public string[]? Cities { get; set; }
    }
}
