using ContentManagementAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContentManagementAPI.Services
{
    public interface IContentService
    {
        Task<Content> GetContentByIdAsync(int id);
        Task<IEnumerable<Content>> GetAllContentsAsync();
        Task<Content> CreateContentAsync(Content content);
        Task<Content> UpdateContentAsync(Content content);
        Task DeleteContentAsync(int id);
        Task<Content> SaveDraftAsync(Content content);
        Task AutoSaveContentAsync(Content content);
    }
}