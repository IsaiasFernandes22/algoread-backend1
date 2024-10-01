using Microsoft.AspNetCore.Mvc;
using YourNamespace.Models;
using YourNamespace.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContentController : ControllerBase
    {
        // Simulação de um "banco de dados" em memória para armazenar os conteúdos
        private static List<ContentSubmission> _contentDatabase = new List<ContentSubmission>();
        private readonly IEmailService _emailService;

        // Lista de revisores (você pode pegar isso de um banco de dados real)
        private static List<string> _reviewersEmails = new List<string>
        {
            "revisor1@dominio.com",
            "revisor2@dominio.com"
        };

        public ContentController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        // Endpoint para submissão de conteúdo
        [HttpPost("submit-for-review")]
        public async Task<IActionResult> SubmitForReview([FromBody] ContentSubmission submission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Alterar o status para "Aguardando aprovação"
            submission.Status = "Aguardando aprovação";

            // Simular salvamento no banco de dados (no caso real, você salvaria no DB)
            _contentDatabase.Add(submission);

            // Notificar os revisores por email
            string contentLink = $"link base de envio{submission.Title}"; // enviando via titulo ou id se for unico
            string subject = "Novo conteúdo aguardando revisão";
            string message = $"Um novo conteúdo foi enviado para revisão.<br><a href='{contentLink}'>Clique aqui para revisar o conteúdo</a>";

            foreach (var reviewerEmail in _reviewersEmails)
            {
                await _emailService.SendEmailAsync(reviewerEmail, subject, message);
            }

            return Ok(new
            {
                Message = "Conteúdo enviado para revisão com sucesso e revisores notificados.",
                Content = submission
            });
        }
    }
}
