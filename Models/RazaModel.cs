using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonajesWebAPI.Models;

public class Raza {

    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }

    public List<Personaje> Personajes { get; set; } = new List<Personaje>();

}
