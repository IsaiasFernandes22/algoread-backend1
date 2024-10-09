using System.ComponentModel.DataAnnotations;

namespace ContentManagementAPI.DTOs
{
    public class AuthDto
    {
        [Required]
        public string Username { get; init; }
        
        [Required]
        public string Password { get; init; }
    }
}
