namespace CookingPot.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CookingPot.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class UserRolesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            var user = await userManager.FindByIdAsync("5eb66a9e-afbb-4db4-a322-51234c72daab");
            var role = await roleManager.FindByNameAsync("Administrator");

            var exists = dbContext.UserRoles.Any(ur => ur.UserId == user.Id && ur.RoleId == role.Id);

            if (exists)
            {
                return;
            }

            await dbContext.UserRoles.AddAsync(new IdentityUserRole<string>
            {
                UserId = user.Id,
                RoleId = role.Id,
            });
        }
    }
}
