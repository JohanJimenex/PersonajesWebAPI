
using PersonajesWebAPI.Models;

namespace PersonajesWebAPI.Services;

public class PersonajeService : BaseService<Personaje> {

    public PersonajeService(PersonajeDbContext context) : base(context) { }

}
