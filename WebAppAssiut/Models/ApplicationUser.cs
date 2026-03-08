using Microsoft.AspNetCore.Identity;

namespace WebAppAssiut.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? Address { get; set; }
    }
}
