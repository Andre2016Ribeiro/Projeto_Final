﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassBackendBotanica;
using BotanicaContext;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace botanicaencomedasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncomendasController : ControllerBase
    {
        private readonly WebApplicationBackendBotanicaContext _context;

        public EncomendasController(WebApplicationBackendBotanicaContext context)
        {
            _context = context;
        }





     
        // GET: api/<EncomendasController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Encomenda>>> Get()
        {
            if (_context.Encomenda == null)
            {
                return NotFound();
            }
            return await _context.Encomenda.ToListAsync();
        }

        // GET api/<EncomendasController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Encomenda>> Get(int id)
        {
            if (_context.Encomenda == null)
            {
                return NotFound();
            }
            var encomenda = await _context.Encomenda.FindAsync(id);

            if (encomenda == null)
            {
                return NotFound();
            }

            return encomenda;
        }

        // POST api/<EncomendasController>
        [HttpPost]
        public async Task<ActionResult<Encomenda>> Post(Encomenda encomenda)
        {
            if (_context.Encomenda == null)
            {
                return Problem("Entity set 'PopulacaoAPIContext.City'  is null.");
            }
            _context.Encomenda.Add(encomenda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEncomenda", new { id = encomenda.Id }, encomenda);
        }

        // PUT api/<EncomendasController>/5
        [HttpPut]
        public async Task<IActionResult> Put(int id, Encomenda encomenda)
        {
            if (id != encomenda.Id)
            {
                return BadRequest();
            }

            _context.Entry(encomenda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EncomendaExists(id))
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

        // DELETE api/<EncomendasController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Encomenda == null)
            {
                return NotFound();
            }
            var encomenda = await _context.Encomenda.FindAsync(id);
            if (encomenda == null)
            {
                return NotFound();
            }

            _context.Encomenda.Remove(encomenda);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool EncomendaExists(int id)
        {
            return (_context.Encomenda?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
