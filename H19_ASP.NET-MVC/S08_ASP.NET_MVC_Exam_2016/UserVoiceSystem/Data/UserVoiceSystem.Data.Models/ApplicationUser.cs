namespace UserVoiceSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        private ICollection<Idea> ideas;
        private ICollection<Comment> comments;

        public ApplicationUser()
        {
            this.ideas = new HashSet<Idea>();
            this.comments = new HashSet<Comment>();
        }

        [Required]
        [MaxLength(15)]
        [MinLength(7)]
        [RegularExpression(@"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$", ErrorMessage = "Invalid IP address !")]
        public string Ip { get; set; }

        [Range(0, 10, ErrorMessage = "Out of range !")]
        [DefaultValue(10)]
        public int VotePoints { get; set; }

        public virtual ICollection<Idea> Ideas
        {
            get { return this.ideas; }
            set { this.ideas = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
