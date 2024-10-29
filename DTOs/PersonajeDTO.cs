using System.Text.Json.Serialization;
using PersonajesWebAPI.Models;

namespace PersonajesWebAPI.DTOs;

public class PersonajeDTO {
    // [JsonIgnore ]
    // public int Id { get; set; }
    public string Nombre { get; set; }
    public int Nivel { get; set; }

    public RazaDTO Raza { get; set; }
    public List<HabilidadDTO> Habilidades { get; set; } = new List<HabilidadDTO>();
}