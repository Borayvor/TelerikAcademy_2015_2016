namespace MyApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;


    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        [StringLength( 30, ErrorMessage = "First name must be between 2 and 30 characters long", MinimumLength = 2 )]
        public string FirstName { get; set; }

        [StringLength( 30, ErrorMessage = "Last name be between 2 and 30 characters long", MinimumLength = 2 )]
        public string LastName { get; set; }

        public DateTime? BirthDateTime { get; set; }

        [MaxLength( 500 )]
        public string ProfileImageUrl { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync( UserManager<User> manager )
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync( this, DefaultAuthenticationTypes.ApplicationCookie );

            // Add custom user claims here
            return userIdentity;
        }
    }
}
