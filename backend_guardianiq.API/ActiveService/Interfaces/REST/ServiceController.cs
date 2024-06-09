using backend_guardianiq.API.ActiveService.Application.Internal;
using backend_guardianiq.API.ActiveService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend_guardianiq.API.ActiveService.Interfaces.REST;

[Route("api/[controller]")]
[ApiController]
public class ServiceController : ControllerBase
{
    private readonly ServiceService _serviceService;

    public ServiceController(ServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    [HttpGet]
    public async Task<IEnumerable<Service>> GetAllAsync()
    {
        var employees = await _serviceService.ListAsync();
        return employees;
    }

    [HttpPost]
    public async Task<ActionResult<Service>> PostAsync([FromBody] Service service)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var createdEmployee = await _serviceService.SaveAsync(service);
            return CreatedAtAction(nameof(GetAllAsync), createdEmployee);
        }
        catch (Exception ex)
        {
            // Log the exception or handle it accordingly
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Service>> PutAsync(int id, [FromBody] Service service)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var updatedEmployee = await _serviceService.UpdateAsync(id, service);

            if (updatedEmployee == null)
            {
                return NotFound();
            }

            return updatedEmployee;
        }
        catch (Exception ex)
        {
            // Log the exception or handle it accordingly
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        try
        {
            var success = await _serviceService.DeleteAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }
}