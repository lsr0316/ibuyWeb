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
    public class itemDetailsController : ControllerBase
    {
        private readonly itemDetailContext _context;

        public itemDetailsController(itemDetailContext context)
        {
            _context = context;
        }

        // GET: api/itemDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<itemDetail>>> GetitemDetail()
        {
            return await _context.itemDetail.ToListAsync();
        }

        // GET: api/itemDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<itemDetail>> GetitemDetail(long id)
        {
            var itemDetail = await _context.itemDetail.FindAsync(id);

            if (itemDetail == null)
            {
                return NotFound();
            }

            return itemDetail;
        }

        // PUT: api/itemDetails/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutitemDetail(long id, itemDetail itemDetail)
        {
            if (id != itemDetail.id)
            {
                return BadRequest();
            }

            _context.Entry(itemDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!itemDetailExists(id))
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

        // POST: api/itemDetails
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<itemDetail>> PostitemDetail(itemDetail itemDetail)
        {
            _context.itemDetail.Add(itemDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetitemDetail", new { id = itemDetail.id }, itemDetail);
        }

        // DELETE: api/itemDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<itemDetail>> DeleteitemDetail(long id)
        {
            var itemDetail = await _context.itemDetail.FindAsync(id);
            if (itemDetail == null)
            {
                return NotFound();
            }

            _context.itemDetail.Remove(itemDetail);
            await _context.SaveChangesAsync();

            return itemDetail;
        }

        private bool itemDetailExists(long id)
        {
            return _context.itemDetail.Any(e => e.id == id);
        }
    }
}
