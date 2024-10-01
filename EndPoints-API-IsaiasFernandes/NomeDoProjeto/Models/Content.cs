using System.ComponentModel.DataAnnotations;

namespace EndPontsAPI.Models
{
    public class Content
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        public bool IsPublic { get; set; }

        public int UserId { get; set; }
    }
}
