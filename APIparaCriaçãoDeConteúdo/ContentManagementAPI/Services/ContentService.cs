using System.Collections.Generic;
using System.Threading.Tasks;
using ContentManagementAPI.Models;
using ContentManagementAPI.Repositories; // Adicione esta linha

namespace ContentManagementAPI.Services
{
    public class ContentService : IContentService
    {
        private readonly IContentRepository _contentRepository;

        public ContentService(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public async Task<Content> GetContentByIdAsync(int id)
        {
            return await _contentRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Content>> GetAllContentsAsync()
        {
            return await _contentRepository.GetAllAsync();
        }

        public async Task<Content> CreateContentAsync(Content content)
        {
            return await _contentRepository.CreateAsync(content);
        }

        public async Task<Content> UpdateContentAsync(Content content)
        {
            return await _contentRepository.UpdateAsync(content);
        }

        public async Task DeleteContentAsync(int id)
        {
            await _contentRepository.DeleteAsync(id);
        }
    }
}
