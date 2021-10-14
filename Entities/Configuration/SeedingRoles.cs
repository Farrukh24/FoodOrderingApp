using Entities.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class SeedingRoles
    {
        public static async Task SeedRolesAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Models.Enum.Roles.Customer.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Models.Enum.Roles.Admin.ToString()));
        }

        public static async Task SeedSuperAdminAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new User
            {
                UserName = "Farrukh2423@gmail.com",
                Email = "Farrukh2423@gmail.com",
                FirstName = "Farrukh",
                LastName = "Kholmatov",
                PhoneNumber = "977072406",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Farrukh2423#");
                    await roleManager.CreateAsync(new IdentityRole(Models.Enum.Roles.Customer.ToString()));
                    await roleManager.CreateAsync(new IdentityRole(Models.Enum.Roles.Admin.ToString()));


                }
            }
        }
    }
}
