using Microsoft.AspNetCore.Mvc;
using ContentManagementAPI.Services; // Adicione esta linha
using ContentManagementAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContentManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContentController : ControllerBase
    {
        private readonly IContentService _contentService;

        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Content>> GetById(int id)
        {
            var content = await _contentService.GetContentByIdAsync(id);
            if (content == null)
            {
                return NotFound();
            }
            return Ok(content);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Content>>> GetAll()
        {
            var contents = await _contentService.GetAllContentsAsync();
            return Ok(contents);
        }

        [HttpPost]
        public async Task<ActionResult<Content>> Create(Content content)
        {
            var createdContent = await _contentService.CreateContentAsync(content);
            return CreatedAtAction(nameof(GetById), new { id = createdContent.Id }, createdContent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Content content)
        {
            if (id != content.Id)
            {
                return BadRequest();
            }
            await _contentService.UpdateContentAsync(content);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _contentService.DeleteContentAsync(id);
            return NoContent();
        }
    }
}
