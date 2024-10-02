using Microsoft.AspNetCore.Mvc;
using ContentManagementAPI.Data;
using ContentManagementAPI.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ContentController : ControllerBase
{
    private readonly AppDbContext _context;

    public ContentController(AppDbContext context)
    {
        _context = context;
    }

    // Endpoint de criação de conteúdo
    [HttpPost]
    public IActionResult CreateContent([FromBody] Content content)
    {
        if (content == null || string.IsNullOrEmpty(content.Title) || string.IsNullOrEmpty(content.Body))
            return BadRequest("Título e conteúdo são obrigatórios.");

        content.CreatedAt = DateTime.UtcNow;
        content.UpdatedAt = DateTime.UtcNow;
        content.Author = User.Identity.Name; // O autor será o usuário autenticado

        _context.Contents.Add(content);
        _context.SaveChanges();

        return Ok(new { message = "Conteúdo criado com sucesso!" });
    }

    // Endpoint de edição de conteúdo
    [HttpPut("{id}")]
    public IActionResult UpdateContent(int id, [FromBody] Content content)
    {
        var existingContent = _context.Contents.FirstOrDefault(c => c.Id == id);

        if (existingContent == null)
            return NotFound("Conteúdo não encontrado.");

        if (existingContent.Author != User.Identity.Name)
            return Forbid("Você não tem permissão para editar este conteúdo.");

        existingContent.Title = content.Title ?? existingContent.Title;
        existingContent.Body = content.Body ?? existingContent.Body;
        existingContent.IsPublic = content.IsPublic;
        existingContent.UpdatedAt = DateTime.UtcNow;

        _context.Contents.Update(existingContent);
        _context.SaveChanges();

        return Ok(new { message = "Conteúdo atualizado com sucesso!" });
    }

    // Endpoint de deleção de conteúdo
    [HttpDelete("{id}")]
    public IActionResult DeleteContent(int id)
    {
        var content = _context.Contents.FirstOrDefault(c => c.Id == id);

        if (content == null)
            return NotFound("Conteúdo não encontrado.");

        if (content.Author != User.Identity.Name)
            return Forbid("Você não tem permissão para deletar este conteúdo.");

        _context.Contents.Remove(content);
        _context.SaveChanges();

        return Ok(new { message = "Conteúdo deletado com sucesso!" });
    }

    // Endpoint para listagem de conteúdos
    [HttpGet]
    public IActionResult GetAllContents()
    {
        var contents = _context.Contents.Where(c => c.IsPublic).ToList();
        return Ok(contents);
    }

    // Endpoint para buscar conteúdo específico
    [HttpGet("{id}")]
    public IActionResult GetContent(int id)
    {
        var content = _context.Contents.FirstOrDefault(c => c.Id == id && c.IsPublic);

        if (content == null)
            return NotFound("Conteúdo não encontrado.");

        return Ok(content);
    }
}
