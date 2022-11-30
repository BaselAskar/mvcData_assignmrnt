using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace mvcData_assignmrnt.Models.DTOs
{
    [BindProperties]
    public class UpdatePersonView
    {
        [Required]
        public int Id { get; set; }

        public string? Name { get; set; }
        public int PhoneNumber { get; set; }
        public string? City { get; set; }

    }
}
