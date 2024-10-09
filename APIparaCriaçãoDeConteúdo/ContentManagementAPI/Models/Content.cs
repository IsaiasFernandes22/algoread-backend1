using System.ComponentModel.DataAnnotations;

namespace ContentManagementAPI.Models
{
    public class Content
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Body { get; set; } = string.Empty;
    }
}
