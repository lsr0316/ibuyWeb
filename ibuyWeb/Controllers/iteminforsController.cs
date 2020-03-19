using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ibuyWeb.Model;

namespace ibuyWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class iteminforsController : ControllerBase
    {
        private readonly iteminforContent _context;

        public iteminforsController(iteminforContent context)
        {
            _context = context;
        }

        // GET: api/iteminfors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<iteminfor>>> Getiteminfor()
        {
            return await _context.iteminfor.ToListAsync();
        }

        // GET: api/iteminfors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<iteminfor>> Getiteminfor(long id)
        {
            var iteminfor = await _context.iteminfor.FindAsync(id);

            if (iteminfor == null)
            {
                return NotFound();
            }

            return iteminfor;
        }

        // PUT: api/iteminfors/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putiteminfor(long id, iteminfor iteminfor)
        {
            if (id != iteminfor.id)
            {
                return BadRequest();
            }

            _context.Entry(iteminfor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!iteminforExists(id))
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

        // POST: api/iteminfors
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<iteminfor>> Postiteminfor(iteminfor iteminfor)
        {
            _context.iteminfor.Add(iteminfor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getiteminfor", new { id = iteminfor.id }, iteminfor);
        }

        // DELETE: api/iteminfors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<iteminfor>> Deleteiteminfor(long id)
        {
            var iteminfor = await _context.iteminfor.FindAsync(id);
            if (iteminfor == null)
            {
                return NotFound();
            }

            _context.iteminfor.Remove(iteminfor);
            await _context.SaveChangesAsync();

            return iteminfor;
        }

        private bool iteminforExists(long id)
        {
            return _context.iteminfor.Any(e => e.id == id);
        }
    }
}
