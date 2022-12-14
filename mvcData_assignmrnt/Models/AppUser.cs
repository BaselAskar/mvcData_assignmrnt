using Microsoft.AspNetCore.Identity;

namespace mvcData_assignmrnt.Models
{
    public class AppUser : IdentityUser
    {
        public DateTime BirthDay { get; set; }
    }
}
