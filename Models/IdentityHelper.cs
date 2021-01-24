using Microsoft.AspNetCore.Identity;
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
            options.SignIn.RequireConfirmedEmail = false;
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
