using Microsoft.AspNetCore.Identity;

namespace ContentManagementAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string CustomProperty { get; set; } = string.Empty; 

        public ApplicationUser() { }
    }
}
