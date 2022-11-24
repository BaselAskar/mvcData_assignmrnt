using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace mvcData_assignmrnt.Models.DTOs
{
    [BindProperties(SupportsGet = true)]
    public class CreatePersonView
    {        

        [Display(Name = "First name")]
        [StringLength(15,MinimumLength = 3,ErrorMessage = "The Name must be between 3 and 15 charecters")]
        [Required]
        public string? Name { get; set; }

        public int PhoneNumber { get; set; }



        [Required(ErrorMessage = "You have to add the City")]
        [Display(Name = "City")]
        public string? CityName { get; set; }

    }
}
