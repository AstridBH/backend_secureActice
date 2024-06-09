using backend_guardianiq.API.ActiveService.Domain.Models;

namespace backend_guardianiq.API.ActiveService.Domain.Services;

public interface IServiceService
{
    Task<IEnumerable<Service>> ListAsync();
    Task<Service> SaveAsync(Service service);
    Task<Service> UpdateAsync(int id, Service service);
    Task<bool> DeleteAsync(int id);
}