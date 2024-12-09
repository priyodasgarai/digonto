using Microsoft.AspNetCore.Identity;

namespace digonto.Models.Identity
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;

    }
}