namespace backend_guardianiq.API.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}