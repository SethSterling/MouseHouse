using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
 * Identity settings can be changed in this class. 
 * Claims Identity, Lockout, Password, Sign in, Tokens, User, Cookie settings,
 * and Password Hasher options can be modified in the SetIdentityOptions method. 
 * See documentation for more information: https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity-configuration?view=aspnetcore-5.0
 */

namespace MouseHouse.Models
{
    public class IdentityHelper
    {
        // Roles
        public const string Administrator = "administrator";
        public const string Customer = "customer";

        /// <summary>
        /// Creates roles if they are passed in as strings
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public static async Task CreateRoles(IServiceProvider provider, params string[] roles)
        {
            RoleManager<IdentityRole> roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();

            foreach (string role in roles)
            {
                bool doesRoleExist = await roleManager.RoleExistsAsync(role);
                if (!doesRoleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        /// <summary>
        /// Creates a default administator account with an username, email, and password. 
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static async Task CreateDefaultAdministrator(IServiceProvider provider)
        {
            const string email = "administrator@mousehouse.com";
            const string username = "administrator";
            const string password = "password";

            var userManager = provider.GetRequiredService<UserManager<IdentityUser>>();

            if (userManager.Users.Count() == 0)
            {
                IdentityUser administrator = new IdentityUser()
                {
                    Email = email,
                    UserName = username
                };

                // creating the administrator
                await userManager.CreateAsync(administrator, password);
                await userManager.AddToRoleAsync(administrator, Administrator);
            }
        }

        /// <summary>
        /// Sets Identity options for sign in procedures, passwords, and lockout options:
        /// Sign in options don't require a confirmed email or phone number.
        /// Password strength requirement is only 8 characters, no required uppercase/lowercase/digits/special characters.
        /// Lock out timespan is 10 minutes with maximum 5 failed attempts. 
        /// </summary>
        /// <param name="options"></param>
        public static void SetIdentityOptions(IdentityOptions options)
        {
            // sign in options
            options.SignIn.RequireConfirmedEmail = true;
            options.SignIn.RequireConfirmedPhoneNumber = false;

            // password options
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 8;

            // lockout options
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            options.Lockout.MaxFailedAccessAttempts = 5;
        }
    }
}
