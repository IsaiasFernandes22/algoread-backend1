using Microsoft.AspNetCore.Mvc;
using ContentManagementAPI.Services;
using ContentManagementAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

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

        [HttpPost("draft")]
        public async Task<ActionResult<Content>> SaveDraft(Content content)
        {
            content.IsDraft = true;
            var savedDraft = await _contentService.SaveDraftAsync(content);
            return Ok(savedDraft);
        }

        [HttpPut("autosave")]
        public async Task<IActionResult> AutoSave(Content content)
        {
            await _contentService.AutoSaveContentAsync(content);
            return NoContent();
        }
    }
}
