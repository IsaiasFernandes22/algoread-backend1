using System.Collections.Generic;
using System.Threading.Tasks;
using ContentManagementAPI.Models;

namespace ContentManagementAPI.Repositories
{
    public interface IContentRepository
    {
        Task<Content> GetByIdAsync(int id);
        Task<IEnumerable<Content>> GetAllAsync();
        Task<Content> CreateAsync(Content content);
        Task<Content> UpdateAsync(Content content);
        Task DeleteAsync(int id);
    }
}
