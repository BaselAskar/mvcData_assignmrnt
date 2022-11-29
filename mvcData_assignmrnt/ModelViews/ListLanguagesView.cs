using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace mvcData_assignmrnt.ModelViews
{
    public class ListLanguagesView
    {
        [Required(ErrorMessage = "You have to add the name of language...")]
        [BindProperty]
        public string? Name { get; set; }

        public List<LanguageView> Languages { get; set; } = new List<LanguageView>();
    }
}
