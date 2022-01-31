using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTiempo.Data;
using WebApiTiempo.Models;

namespace WebApiTiempo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiempoItemsController : ControllerBase
    {
        private readonly WebApiTiempoContext _context;

        public TiempoItemsController(WebApiTiempoContext context)
        {
            _context = context;
        }

        // GET: api/TiempoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiempoItem>>> GetTiempoItem()
        {
            return await _context.TiempoItem.ToListAsync();
        }

        // GET: api/TiempoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TiempoItem>> GetTiempoItem(string id)
        {
            var tiempoItem = await _context.TiempoItem.FindAsync(id);

            if (tiempoItem == null)
            {
                return NotFound();
            }

            return tiempoItem;
        }

        // PUT: api/TiempoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTiempoItem(string id, TiempoItem tiempoItem)
        {
            if (id != tiempoItem.Municipio)
            {
                return BadRequest();
            }

            _context.Entry(tiempoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiempoItemExists(id))
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

        // POST: api/TiempoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TiempoItem>> PostTiempoItem(TiempoItem tiempoItem)
        {
            _context.TiempoItem.Add(tiempoItem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TiempoItemExists(tiempoItem.Municipio))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTiempoItem", new { id = tiempoItem.Municipio }, tiempoItem);
        }

        // DELETE: api/TiempoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTiempoItem(string id)
        {
            var tiempoItem = await _context.TiempoItem.FindAsync(id);
            if (tiempoItem == null)
            {
                return NotFound();
            }

            _context.TiempoItem.Remove(tiempoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TiempoItemExists(string id)
        {
            return _context.TiempoItem.Any(e => e.Municipio == id);
        }
    }
}
