using Microsoft.AspNetCore.Identity;

namespace MyBookStore.API.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
    }
}
