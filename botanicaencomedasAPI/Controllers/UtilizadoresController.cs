using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassBackendBotanica;
using BotanicaContext;

namespace botanicaencomedasAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UtilizadoresController : ControllerBase
    {
        private readonly WebApplicationBackendBotanicaContext _context;

        public UtilizadoresController(WebApplicationBackendBotanicaContext context)
        {
            _context = context;
        }






        // GET: api/<UtilizadoresController>
        [HttpGet("GetByName/{name}")]
            public async Task<ActionResult<IEnumerable<Utilizador>>> GetByName(string name)
            {
                if (_context.Utilizador == null)
                {
                    return NotFound();
                }
            var usertolist = _context.Utilizador.Where(x => x.UserName == name)
                 .ToList();
            return usertolist;
            }

            // GET api/<UtilizadoresController>/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Utilizador>> Get(int id)
            {
                if (_context.Utilizador == null)
                {
                    return NotFound();
                }
                var Utilizador = await _context.Utilizador.FindAsync(id);

                if (Utilizador == null)
                {
                    return NotFound();
                }

                return Utilizador;
            }

            // POST api/<UtilizadoresController>
            [HttpPost]
            public async Task<ActionResult<Utilizador>> Post(Utilizador Utilizador)
            {
                if (_context.Utilizador == null)
                {
                    return Problem("Entity set 'PopulacaoAPIContext.City'  is null.");
                }
                _context.Utilizador.Add(Utilizador);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetUtilizador", new { id = Utilizador.Id }, Utilizador);
            }

            // PUT api/<UtilizadoresController>/5
            [HttpPut("{id}")]
            public async Task<IActionResult> Put(int id, Utilizador Utilizador)
            {
                if (id != Utilizador.Id)
                {
                    return BadRequest();
                }

                _context.Entry(Utilizador).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilizadorExists(id))
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

            // DELETE api/<UtilizadoresController>/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                if (_context.Utilizador == null)
                {
                    return NotFound();
                }
                var Utilizador = await _context.Utilizador.FindAsync(id);
                if (Utilizador == null)
                {
                    return NotFound();
                }

                _context.Utilizador.Remove(Utilizador);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            private bool UtilizadorExists(int id)
            {
                return (_context.Utilizador?.Any(e => e.Id == id)).GetValueOrDefault();
            }
        
    }
}
