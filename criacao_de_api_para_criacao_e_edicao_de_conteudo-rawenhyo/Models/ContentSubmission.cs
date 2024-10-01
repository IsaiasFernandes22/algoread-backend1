using System.ComponentModel.DataAnnotations;

namespace YourNamespace.Models
{
    public class ContentSubmission
    {
        [Required(ErrorMessage = "Título é obrigatório")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Tags são obrigatórias")]
        public string Tags { get; set; }

        public string Status { get; set; } = "Rascunho"; // Padrão: "Rascunho"
    }
}
