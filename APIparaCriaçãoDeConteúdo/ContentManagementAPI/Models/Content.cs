using System; // Certifique-se de que esta linha esteja presente
using System.ComponentModel.DataAnnotations;

namespace ContentManagementAPI.Models
{
    public class Content
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Body { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }

        public Content()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
