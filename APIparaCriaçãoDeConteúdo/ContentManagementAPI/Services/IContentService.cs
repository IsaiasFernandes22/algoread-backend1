using System.Threading.Tasks;
using ContentManagementAPI.Models;

namespace ContentManagementAPI.Services
{
    public interface IContentService
    {
        Task<Content> UpdateContentAsync(Content content);
        // Outros métodos
    }
}
