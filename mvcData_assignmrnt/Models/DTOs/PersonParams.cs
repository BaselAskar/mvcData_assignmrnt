using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace mvcData_assignmrnt.Models.DTOs
{
    [BindProperties(SupportsGet = true)]
    public class PersonParams
    {
        public int Id { get; set; }
        

        [Display(Name = "First name")]
        [StringLength(15,MinimumLength = 3,ErrorMessage = "First Name must be between 3 and 15 charecters")]
        [Required]
        public string FirstName { get; set; }


        [Display(Name = "Last name")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Last Name must be between 3 and 15 charecters")]
        [Required]
        public string LastName { get; set; }


        [Range(1,100,ErrorMessage = "Not Allowed age ..!")]
        public int Age { get; set; }



        [Required(ErrorMessage = "You have to add the City")]
        public string City { get; set; }

    }
}
