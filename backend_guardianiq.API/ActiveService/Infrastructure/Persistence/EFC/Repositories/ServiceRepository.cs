using backend_guardianiq.API.ActiveService.Domain.Models;
using backend_guardianiq.API.ActiveService.Domain.Repositories;
using backend_guardianiq.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend_guardianiq.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend_guardianiq.API.ActiveService.Infrastructure.Persistence.EFC.Repositories;

public class ServiceRepository : BaseRepository, IServiceRepository
{
    public ServiceRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Service>> ListAsync()
    {
        return await _context.Service.ToListAsync();
    }

    public async Task AddAsync(Service service)
    {
        await _context.Service.AddAsync(service);
    }

    public async Task<Service> FindByIdAsync(int id)
    {
        return await _context.Service.FindAsync(id);
    }

    public void Update(Service service)
    {
        _context.Service.Update(service);
    }

    public void Remove(Service service)
    {
        _context.Service.Remove(service);
    }
}