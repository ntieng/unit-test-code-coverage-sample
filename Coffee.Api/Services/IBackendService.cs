
using Coffee.Api.Models;

namespace Coffee.Api.Services
{
    public interface IBackendService
    {
        Task<T?> GetNew<T>(CancellationToken cancellationToken = default);
    }
}
