using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestRest.Modelos;
using TestRestDirectory.Models;

namespace TestRestDirectory.Controladores
{
    /// <summary>
    /// Controlador de Entidad=Personas
    /// </summary>
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly DirectoryContext _context;

        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        /// <param name="context"></param>
        public PersonasController(DirectoryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtener Personas
        /// GET: api/Personas
        /// </summary>
        /// <returns>Lista Personas</returns>
        [HttpGet]
        public IEnumerable<Personas> GetPersonas()
        {
            return _context.Personas;
        }

        /// <summary>
        /// Obtener Persona por ID
        /// GET: api/Personas/5
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Persona</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonas([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personas = await _context.Personas.FindAsync(id);

            if (personas == null)
            {
                return NotFound();
            }

            return Ok(personas);
        }

        /// <summary>
        /// Actualiza una Persona
        /// PUT: api/Personas/5
        /// </summary>
        /// <param name="id">Identificador Persona</param>
        /// <param name="personas">JSON Persona</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonas([FromRoute] int id, [FromBody] Personas personas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personas.Id)
            {
                return BadRequest();
            }

            _context.Entry(personas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Crea una Persona
        /// POST: api/Personas
        /// </summary>
        /// <param name="personas">JSON Persona</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostPersonas([FromBody] Personas personas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Personas.Add(personas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonas", new { id = personas.Id }, personas);
        }

        /// <summary>
        /// Elimina una persona
        /// DELETE: api/Personas/5
        /// </summary>
        /// <param name="id">Identificador Persona</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonas([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personas = await _context.Personas.FindAsync(id);
            if (personas == null)
            {
                return NotFound();
            }

            _context.Personas.Remove(personas);
            await _context.SaveChangesAsync();

            return Ok(personas);
        }

        private bool PersonasExists(int id)
        {
            return _context.Personas.Any(e => e.Id == id);
        }
    }
}