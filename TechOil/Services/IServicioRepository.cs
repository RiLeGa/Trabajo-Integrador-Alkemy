using TechOil.Models;
namespace TechOil.Services
{ 

public interface IServicioRepository
{
    IEnumerable<Servicio> GetAllServicios();
}
}