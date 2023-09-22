using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassBackendBotanica;
using BotanicaContext;

namespace botanicaencomedasAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ArtigosController : ControllerBase
    {
        private readonly WebApplicationBackendBotanicaContext _context;

        public ArtigosController(WebApplicationBackendBotanicaContext context)
        {
            _context = context;
        }






        // GET: api/<ArtigosController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artigo>>> Get()
        {
            if (_context.Artigo == null)
            {
                return NotFound();
            }
            return await _context.Artigo.ToListAsync();
        }

        // GET api/<ArtigosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artigo>> Get(int id)
        {
            if (_context.Artigo == null)
            {
                return NotFound();
            }
            var Artigo = await _context.Artigo.FindAsync(id);

            if (Artigo == null)
            {
                return NotFound();
            }

            return Artigo;
        }

        // POST api/<ArtigosController>
        [HttpPost]
        public async Task<ActionResult<Artigo>> Post(Artigo Artigo)
        {
            if (_context.Artigo == null)
            {
                return Problem("Entity set 'PopulacaoAPIContext.City'  is null.");
            }
            _context.Artigo.Add(Artigo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtigo", new { id = Artigo.Id }, Artigo);
        }

        // PUT api/<ArtigosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Artigo Artigo)
        {
            if (id != Artigo.Id)
            {
                return BadRequest();
            }

            _context.Entry(Artigo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtigoExists(id))
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

        // DELETE api/<ArtigosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Artigo == null)
            {
                return NotFound();
            }
            var Artigo = await _context.Artigo.FindAsync(id);
            if (Artigo == null)
            {
                return NotFound();
            }

            _context.Artigo.Remove(Artigo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool ArtigoExists(int id)
        {
            return (_context.Artigo?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
