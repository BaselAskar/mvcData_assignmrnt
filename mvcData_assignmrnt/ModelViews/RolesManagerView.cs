using Microsoft.AspNetCore.Identity;
using mvcData_assignmrnt.Models;

namespace mvcData_assignmrnt.ModelViews
{
    public class RolesManagerView
    {
        public List<AppUser> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }

    }
}
