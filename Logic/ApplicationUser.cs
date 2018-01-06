using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace Logic

{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public enum Gender
        {
            Male,
            Female
        }

    public class ApplicationUser : IdentityUser
    {
        public string Nickname { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public Gender Gender { get; set; }
        public IEnumerable<Gender> GenderList { get; set; }
        public byte[] Photo { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}