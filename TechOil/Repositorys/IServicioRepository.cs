using TechOil.Models;
namespace TechOil.Repositorys
{ 

public interface IServicioRepository
{
    IEnumerable<Servicio> GetAllServicios();
    public Servicio GetServicioById(int id);
    void AddServicio(Servicio servicio);
    void UpdateServicio(Servicio servicio);
    void DeleteServicio(int id);
    }
}