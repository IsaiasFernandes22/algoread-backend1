using System.Threading.Tasks;
using ContentManagementAPI.Models;
using ContentManagementAPI.Data; // Adicione esta linha
using Microsoft.EntityFrameworkCore;

namespace ContentManagementAPI.Services
{
    public class ContentService : IContentService
    {
        private readonly ApplicationDbContext _context;

        public ContentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Content> UpdateContentAsync(Content content)
        {
            var existingContent = await _context.Contents.FindAsync(content.Id);
            if (existingContent == null)
            {
                return null;
            }

            existingContent.Title = content.Title;
            existingContent.Body = content.Body;
            await _context.SaveChangesAsync();
            return existingContent;
        }

        // Outros métodos
    }
}
