using System.Runtime.InteropServices.JavaScript;

namespace backend_guardianiq.API.ActiveService.Domain.Models;

public class Service
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Fecha_inicio { get; set; }
    public DateTime Fecha_fin { get; set; }
    
}