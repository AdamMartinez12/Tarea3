using CrudTarea3.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudTarea3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private static List<Persona> personas = new List<Persona>()
        {
            new Persona { Id = 1, Nombre = "Juan Pérez", Correo = "juan@example.com" },
            new Persona { Id = 2, Nombre = "Ana López", Correo = "ana@example.com" }
        };

        // GET: api/persona
        [HttpGet]
        public ActionResult<List<Persona>> Get()
        {
            return Ok(personas);
        }

        // GET: api/persona/1
        [HttpGet("{id}")]
        public ActionResult<Persona> GetById(int id)
        {
            var persona = personas.FirstOrDefault(p => p.Id == id);
            if (persona == null)
                return NotFound("Persona no encontrada.");

            return Ok(persona);
        }

        // POST: api/persona
        [HttpPost]
        public ActionResult Crear(Persona nuevaPersona)
        {
            nuevaPersona.Id = personas.Max(p => p.Id) + 1;
            personas.Add(nuevaPersona);

            return Ok("Persona creada correctamente.");
        }

        // PUT: api/persona/1
        [HttpPut("{id}")]
        public ActionResult Editar(int id, Persona personaEditada)
        {
            var persona = personas.FirstOrDefault(p => p.Id == id);
            if (persona == null)
                return NotFound("Persona no encontrada.");

            persona.Nombre = personaEditada.Nombre;
            persona.Correo = personaEditada.Correo;

            return Ok("Persona actualizada correctamente.");
        }

        // DELETE: api/persona/1
        [HttpDelete("{id}")]
        public ActionResult Eliminar(int id)
        {
            var persona = personas.FirstOrDefault(p => p.Id == id);
            if (persona == null)
                return NotFound("Persona no encontrada.");

            personas.Remove(persona);

            return Ok("Persona eliminada correctamente.");
        }
    }
}
