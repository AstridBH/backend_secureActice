using backend_guardianiq.API.ActiveService.Domain.Repositories;
using backend_guardianiq.API.Shared.Domain.Repositories;
using backend_guardianiq.API.ActiveService.Domain.Models;
using backend_guardianiq.API.ActiveService.Domain.Services;

namespace backend_guardianiq.API.ActiveService.Application.Internal;

public class ServiceService : IServiceService
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ServiceService(IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
    {
        _serviceRepository = serviceRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Service>> ListAsync()
    {
        return await _serviceRepository.ListAsync();
    }

    public async Task<Service> SaveAsync(Service service)
    {
        try
        {
            await _serviceRepository.AddAsync(service);
            await _unitOfWork.CompleteAsync();
            return service;
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while saving the service: {e.Message}", e);
        }
    }

    public async Task<Service> UpdateAsync(int id, Service service)
    {
        var existingService = await _serviceRepository.FindByIdAsync(id);

        if (existingService == null)
        {
            throw new KeyNotFoundException("Service not found.");
        }

        existingService.Name = service.Name;
        existingService.Fecha_inicio = service.Fecha_inicio;
        existingService.Fecha_fin = service.Fecha_fin;

        try
        {
            _serviceRepository.Update(existingService);
            await _unitOfWork.CompleteAsync();
            return existingService;
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while updating the service: {e.Message}", e);
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existingService = await _serviceRepository.FindByIdAsync(id);

        if (existingService == null)
        {
            throw new KeyNotFoundException("Service not found.");
        }

        try
        {
            _serviceRepository.Remove(existingService);
            await _unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while deleting the service: {e.Message}", e);
        }
    }
}