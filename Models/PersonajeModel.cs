namespace PersonajesWebAPI.Models;

public class Personaje {
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Nivel { get; set; }

    public int RazaId { get; set; }
    public Raza Raza { get; set; }

    public List<Habilidad> Habilidades { get; set; } = new List<Habilidad>();

}
