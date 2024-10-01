public class ContentModel
{

    [Required(ErrorMessage = "O título do Artigo é obrigatório")]
    public string Title { get; set; }

    [Required(ErrorMessage = "a Descrição do conteúdo é obrigatório")]
    public string Body { get; set; } 
}


