using System;

namespace ContentManagementAPI.DTOs
{
    public class RegisterResponseDto
    {
        public string UserId { get; set; } = string.Empty; 
        public string Message { get; set; } = string.Empty; 

        public RegisterResponseDto() { }
    }
}
