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
    public class userDetailsController : ControllerBase
    {
        private readonly userDetailContext _context;

        public userDetailsController(userDetailContext context)
        {
            _context = context;
        }

        // GET: api/userDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<userDetail>>> GetuserDetail()
        {
            return await _context.userDetail.ToListAsync();
        }

        // GET: api/userDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<userDetail>> GetuserDetail(long id)
        {
            var userDetail = await _context.userDetail.FindAsync(id);

            if (userDetail == null)
            {
                return NotFound();
            }

            return userDetail;
        }

        // PUT: api/userDetails/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutuserDetail(long id, userDetail userDetail)
        {
            if (id != userDetail.id)
            {
                return BadRequest();
            }

            _context.Entry(userDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userDetailExists(id))
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

        // POST: api/userDetails
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<userDetail>> PostuserDetail(userDetail userDetail)
        {
            _context.userDetail.Add(userDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetuserDetail", new { id = userDetail.id }, userDetail);
        }

        // DELETE: api/userDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<userDetail>> DeleteuserDetail(long id)
        {
            var userDetail = await _context.userDetail.FindAsync(id);
            if (userDetail == null)
            {
                return NotFound();
            }

            _context.userDetail.Remove(userDetail);
            await _context.SaveChangesAsync();

            return userDetail;
        }

        private bool userDetailExists(long id)
        {
            return _context.userDetail.Any(e => e.id == id);
        }
    }
}
