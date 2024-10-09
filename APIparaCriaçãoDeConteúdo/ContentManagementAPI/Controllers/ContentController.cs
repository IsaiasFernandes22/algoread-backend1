using Microsoft.AspNetCore.Mvc;
using ContentManagementAPI.Services;
using ContentManagementAPI.Models;
using System.Threading.Tasks;

namespace ContentManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContentController : ControllerBase
    {
        private readonly IContentService _contentService;

        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContent(int id, Content content)
        {
            if (id != content.Id)
            {
                return BadRequest();
            }

            var updatedContent = await _contentService.UpdateContentAsync(content);
            if (updatedContent == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
