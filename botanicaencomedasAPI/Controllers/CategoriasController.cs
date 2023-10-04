using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassBackendBotanica;
using BotanicaContext;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace botanicaencomedasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly WebApplicationBackendBotanicaContext _context;

        public CategoriasController(WebApplicationBackendBotanicaContext context)
        {
            _context = context;
        }
        // GET: api/<CategoriasController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> Get()
        {
            if (_context.Categorias == null)
            {
                return NotFound();
            }
            return await _context.Categorias.ToListAsync();
        }

        // GET api/<CategoriasController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> Get(int id)
        {
            if (_context.Categorias == null)
            {
                return NotFound();
            }
            var Categorias = await _context.Categorias.FindAsync(id);

            if (Categorias == null)
            {
                return NotFound();
            }

            return Categorias;
        }

        // POST api/<CategoriasController>
        [HttpPost]
        public async Task<ActionResult<Categoria>> Post(Categoria categoria)
        {
            if (_context.Categorias == null)
            {
                return Problem("Entity set 'PopulacaoAPIContext.City'  is null.");
            }
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoria", new { id = categoria.Id }, categoria);
        }

        // PUT api/<CategoriasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
