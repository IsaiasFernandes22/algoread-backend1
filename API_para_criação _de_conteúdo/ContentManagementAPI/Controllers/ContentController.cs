using ContentManagementAPI.Data;
using ContentManagementAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ContentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContentController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Content
        [HttpGet]
        [AllowAnonymous]  // Permitir a visualização pública dos conteúdos
        public async Task<IActionResult> GetContents()
        {
            var contents = await _context.Contents.ToListAsync();
            return Ok(contents);
        }

        // GET: api/Content/5
        [HttpGet("{id}")]
        [AllowAnonymous]  // Permitir a visualização pública de um conteúdo específico
        public async Task<IActionResult> GetContent(int id)
        {
            var content = await _context.Contents.FindAsync(id);

            if (content == null)
            {
                return NotFound("Conteúdo não encontrado.");
            }

            return Ok(content);
        }

        // POST: api/Content
        [HttpPost]
        [Authorize(Roles = "admin, user")]  // Apenas usuários autenticados podem criar conteúdo
        public async Task<IActionResult> CreateContent([FromBody] Content content)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados inválidos.");
            }

            // Associar o conteúdo ao usuário autenticado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized("Usuário não autenticado.");
            }

            content.UserId = int.Parse(userId);

            _context.Contents.Add(content);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContent), new { id = content.Id }, content);
        }

        // PUT: api/Content/5
        [HttpPut("{id}")]
        [Authorize(Roles = "admin, user")]  // Apenas usuários autenticados podem editar conteúdo
        public async Task<IActionResult> EditContent(int id, [FromBody] Content content)
        {
            if (id != content.Id)
            {
                return BadRequest("ID do conteúdo não corresponde.");
            }

            // Verificar se o conteúdo pertence ao usuário autenticado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var existingContent = await _context.Contents.FindAsync(id);

            if (existingContent == null || existingContent.UserId != int.Parse(userId))
            {
                return Forbid("Você não tem permissão para editar este conteúdo.");
            }

            _context.Entry(content).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Contents.Any(e => e.Id == id))
                {
                    return NotFound("Conteúdo não encontrado.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]  
        public async Task<IActionResult> DeleteContent(int id)
        {
            var content = await _context.Contents.FindAsync(id);

            if (content == null)
            {
                return NotFound("Conteúdo não encontrado.");
            }

            _context.Contents.Remove(content);
            await _context.SaveChangesAsync();

            return Ok("Conteúdo deletado com sucesso.");
        }
    }
}
