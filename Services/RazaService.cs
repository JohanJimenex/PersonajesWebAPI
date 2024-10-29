using PersonajesWebAPI.Models;

namespace PersonajesWebAPI.Services;

public class RazaService : BaseService<Raza> {

    public RazaService(PersonajeDbContext context) : base(context) { }

}
