using backend_guardianiq.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace backend_guardianiq.API.Shared.Infrastructure.Persistence.EFC.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}