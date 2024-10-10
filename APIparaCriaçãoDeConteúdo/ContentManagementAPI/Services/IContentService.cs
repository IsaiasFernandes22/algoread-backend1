using System.Collections.Generic;
using System.Threading.Tasks;
using ContentManagementAPI.Models;

namespace ContentManagementAPI.Services
{
    public interface IContentService
    {
        Task<Content> GetContentByIdAsync(int id);
        Task<IEnumerable<Content>> GetAllContentsAsync();
        Task<Content> CreateContentAsync(Content content);
        Task<Content> UpdateContentAsync(Content content);
        Task DeleteContentAsync(int id);
    }
}
