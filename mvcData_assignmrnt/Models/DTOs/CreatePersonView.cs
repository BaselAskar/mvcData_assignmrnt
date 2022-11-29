using Microsoft.AspNetCore.Mvc;
using mvcData_assignmrnt.ModelViews;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace mvcData_assignmrnt.Models.DTOs
{
    [BindProperties(SupportsGet = true)]
    public class CreatePersonView
    {        

        [StringLength(15,MinimumLength = 3,ErrorMessage = "The Name must be between 3 and 15 charecters")]
        [Required]
        public string? Name { get; set; }

        
        public string? PhoneNumber { get; set; }



        [Required(ErrorMessage = "You have to add the City")]
        [Display(Name = "City")]
        public string? CityName { get; set; }


        [Required(ErrorMessage = "You have to add languages....")]
        public string[]? LangsName { get; set; }

        public List<CountryView> Countries { get; set; } = new List<CountryView>();

        public List<LanguageView> Languages { get; set; } = new List<LanguageView>();

    }
}
