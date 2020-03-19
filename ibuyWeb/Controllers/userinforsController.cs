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
    public class userinforsController : ControllerBase
    {
        private readonly userinforContent _context;

        public userinforsController(userinforContent context)
        {
            _context = context;
        }

        // GET: api/userinfors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<userinfor>>> Getuserinfor()
        {
            return await _context.userinfor.ToListAsync();
        }

        // GET: api/userinfors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<userinfor>> Getuserinfor(long id)
        {
            var userinfor = await _context.userinfor.FindAsync(id);

            if (userinfor == null)
            {
                return NotFound();
            }

            return userinfor;
        }

        // PUT: api/userinfors/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putuserinfor(long id, userinfor userinfor)
        {
            if (id != userinfor.id)
            {
                return BadRequest();
            }

            _context.Entry(userinfor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userinforExists(id))
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

        // POST: api/userinfors
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<userinfor>> Postuserinfor(userinfor userinfor)
        {
            _context.userinfor.Add(userinfor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getuserinfor", new { id = userinfor.id }, userinfor);
        }

        // DELETE: api/userinfors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<userinfor>> Deleteuserinfor(long id)
        {
            var userinfor = await _context.userinfor.FindAsync(id);
            if (userinfor == null)
            {
                return NotFound();
            }

            _context.userinfor.Remove(userinfor);
            await _context.SaveChangesAsync();

            return userinfor;
        }

        private bool userinforExists(long id)
        {
            return _context.userinfor.Any(e => e.id == id);
        }
    }
}
