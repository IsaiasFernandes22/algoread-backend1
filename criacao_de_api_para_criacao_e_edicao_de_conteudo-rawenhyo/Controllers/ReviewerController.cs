using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourNamespace.Data;
using YourNamespace.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReviewerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Endpoint para adicionar um revisor
        [HttpPost("add")]
        public async Task<IActionResult> AddReviewer([FromBody] Reviewer reviewer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Reviewers.Add(reviewer);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Revisor adicionado com sucesso.", Reviewer = reviewer });
        }

        // Endpoint para atribuir revisores automaticamente
        [HttpPost("assign-reviews/{contentId}")]
        public async Task<IActionResult> AssignReviews(int contentId)
        {
            // Verifica se o conteúdo existe
            var content = await _context.ContentSubmissions.FindAsync(contentId);
            if (content == null)
            {
                return NotFound("Conteúdo não encontrado.");
            }

            // Selecionar revisores disponíveis
            var availableReviewers = await _context.Reviewers.ToListAsync();
            if (availableReviewers.Count < 2)
            {
                return BadRequest("Não há revisores suficientes disponíveis.");
            }

            // Atribuir dois revisores ao conteúdo
            var assignedReviewers = availableReviewers.Take(2).ToList();
            foreach (var reviewer in assignedReviewers)
            {
                var assignment = new ContentReviewAssignment
                {
                    ContentId = contentId,
                    ReviewerId = reviewer.Id
                };

                _context.ReviewAssignments.Add(assignment);
            }

            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = "Revisores atribuídos com sucesso.",
                AssignedReviewers = assignedReviewers.Select(r => r.Name)
            });
        }

        // Endpoint para visualizar as atribuições de revisores para um conteúdo
        [HttpGet("assignments/{contentId}")]
        public async Task<IActionResult> GetAssignments(int contentId)
        {
            var assignments = await _context.ReviewAssignments
                .Where(a => a.ContentId == contentId)
                .Include(a => a.Reviewer)
                .Select(a => new
                {
                    Reviewer = a.Reviewer.Name
                }).ToListAsync();

            return Ok(assignments);
        }
    }
}
