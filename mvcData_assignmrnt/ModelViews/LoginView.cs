

using System.ComponentModel.DataAnnotations;

namespace mvcData_assignmrnt.ModelViews
{
    public class LoginView
    {
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string? Email { get; set; }

        [Required]
        [StringLength(30,MinimumLength = 6,ErrorMessage = "password must to be between 6 and 30 charecter..")]
        public string? Password { get; set; }

        public string? ReturnUrl { get; set; }

    }
}
