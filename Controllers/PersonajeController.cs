using Microsoft.AspNetCore.Mvc;
using PersonajesWebAPI.DTOs;
using PersonajesWebAPI.Models;
using PersonajesWebAPI.Services;

namespace PersonajesWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonajeController : ControllerBase {

    private readonly PersonajeService _service;

    public PersonajeController(PersonajeService service) {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Personaje>>> GetAll() {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}", Name = "Get")]
    public async Task<ActionResult<Personaje>> Get(int id) {
        var result = await _service.GetById(id);
        if (result == null) {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost]
    public ActionResult<PersonajeDTO> Create([FromBody] PersonajeDTO personajeDTO) {

        var raza = _service;

        var personaje = new Personaje {
            Nombre = personajeDTO.Nombre,
            RazaId = 0,
            Raza = new Raza {
                Id = 0,
                Nombre = personajeDTO.Raza.Nombre,
                Descripcion = personajeDTO.Raza.Descripcion
            },
            Habilidades = personajeDTO.Habilidades.Select(h => new Habilidad {
                Id = 0,
                Nombre = h.Nombre,
                Descripcion = h.Descripcion,
                Poder = h.Poder
            }).ToList()
        };


        var result = _service.Create(personaje);
        // return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        return new CreatedAtRouteResult("Get", new { id = result.Id }, result);

    }
}
