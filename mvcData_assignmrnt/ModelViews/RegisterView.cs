

using System.ComponentModel.DataAnnotations;

namespace mvcData_assignmrnt.ModelViews
{
    public class RegisterView
    {
        [Required(ErrorMessage = "User Name is Required")]
        [Display(Name = "User name")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Emain is Required...")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",ErrorMessage = "Email is not correct structure ....")]
        public string? Email { get; set; }


        [Required(ErrorMessage = "First name is required .... ")]
        [StringLength(20,MinimumLength = 3,ErrorMessage = "First Name must be between 3 and 20 charecter")]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        
        
        [Required(ErrorMessage = "Last name is required .... ")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Last Name must be between 3 and 20 charecter")]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }



        [Phone(ErrorMessage = "Phone number is not correct ...")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Birth date is required ...")]
        [Display(Name = "Birth date")]
        [RegularExpression(@"^\d{4}-((0\d)|(1[012]))-(([012]\d)|3[01])$")]
        [DataType(DataType.Date)]
        public string? BirthDate { get; set; }

        [Required(ErrorMessage = "Password is required....")]
        [StringLength(30,MinimumLength = 6,ErrorMessage = "Password must be between 6 and 30 charecter .....")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        
        
        [Required(ErrorMessage = "Confirm Password is required....")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Confirm Password must be between 6 and 30 charecter .....")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password",ErrorMessage = "Confirm Password and Password is not the same")]
        public string? ConfirmPassword { get; set; }


        [Display(Name = "Keep sigin")]
        public bool KeepSigin { get; set; } = true;



        public string? ReturnUrl { get; set; }

    }
}
