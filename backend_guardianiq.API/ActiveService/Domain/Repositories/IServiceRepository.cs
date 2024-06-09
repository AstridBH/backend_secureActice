using backend_guardianiq.API.ActiveService.Domain.Models;

namespace backend_guardianiq.API.ActiveService.Domain.Repositories;

public interface IServiceRepository
{
    Task<IEnumerable<Service>> ListAsync();
    Task AddAsync(Service service);
    Task<Service> FindByIdAsync(int id);
    void Update(Service service);
    void Remove(Service service);
}