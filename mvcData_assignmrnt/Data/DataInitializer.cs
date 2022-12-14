using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mvcData_assignmrnt.Constants;
using mvcData_assignmrnt.Models;

namespace mvcData_assignmrnt.Data
{
    public class DataInitializer
    {
       

        public static async Task Seed(AppDbContext context,RoleManager<IdentityRole> roleManager,UserManager<AppUser> userManager)
        {
            await context.Database.MigrateAsync();

            if (!context.Roles.Any())
            {
                string[] rolesNames = {Roles.SuperAdmin,Roles.Admin,Roles.User};

                foreach (string roleName in rolesNames)
                {
                    IdentityRole role = new IdentityRole(roleName);

                    await roleManager.CreateAsync(role);
                }


                AppUser superAdmin = new AppUser
                {
                    FirstName = "Super",
                    LastName = "Admin",
                    UserName= "Super Admin",
                    Email = "superAdmin@gmail.com",
                    BirthDay = DateTime.Parse("1985-01-01")
                };



                var identityResult = await userManager.CreateAsync(superAdmin, "Pa$$w0rd");

                if (!identityResult.Succeeded)
                {
                    throw new Exception("super admin has not been added ... !");
                }

                await userManager.AddToRoleAsync(superAdmin,Roles.SuperAdmin);

            }

            //Seeding Languages
            if (!context.Languages.Any())
            {
                List<Language> languages = new List<Language>
                {
                    new Language{Name= "Swedish"},
                    new Language{Name = "English"}
                };

                languages.ForEach(lang => context.Languages.Add(lang));

                await context.SaveChangesAsync();
            }

            if (!context.Countries.Any())
            {
                List<Country> countries = new List<Country>
                {
                    new Country{Name="Sweden",Cities = 
                        new List<City>
                        {
                            new City{Name = "Malmö"},
                            new City{Name = "Växjö"},
                            new City{Name = "Stockholm"}
                        }
                    }
                };


                countries.ForEach(c => context.Countries.Add(c));
                await context.SaveChangesAsync();
            }
        }
    }
}
