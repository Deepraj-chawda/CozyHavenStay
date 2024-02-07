using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CozyHavenStay.Models;

namespace CozyHavenStay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelOwnersController : ControllerBase
    {
        private readonly CozyHavenStayContext _context;

        public HotelOwnersController(CozyHavenStayContext context)
        {
            _context = context;
        }

        // GET: api/HotelOwners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelOwner>>> GetHotelOwners()
        {
          if (_context.HotelOwners == null)
          {
              return NotFound();
          }
            return await _context.HotelOwners.ToListAsync();
        }

        // GET: api/HotelOwners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelOwner>> GetHotelOwner(int id)
        {
          if (_context.HotelOwners == null)
          {
              return NotFound();
          }
            var hotelOwner = await _context.HotelOwners.FindAsync(id);

            if (hotelOwner == null)
            {
                return NotFound();
            }

            return hotelOwner;
        }

        // PUT: api/HotelOwners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelOwner(int id, HotelOwner hotelOwner)
        {
            if (id != hotelOwner.OwnerId)
            {
                return BadRequest();
            }

            _context.Entry(hotelOwner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelOwnerExists(id))
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

        // POST: api/HotelOwners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelOwner>> PostHotelOwner(HotelOwner hotelOwner)
        {
          if (_context.HotelOwners == null)
          {
              return Problem("Entity set 'CozyHavenStayContext.HotelOwners'  is null.");
          }
            _context.HotelOwners.Add(hotelOwner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelOwner", new { id = hotelOwner.OwnerId }, hotelOwner);
        }

        // DELETE: api/HotelOwners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelOwner(int id)
        {
            if (_context.HotelOwners == null)
            {
                return NotFound();
            }
            var hotelOwner = await _context.HotelOwners.FindAsync(id);
            if (hotelOwner == null)
            {
                return NotFound();
            }

            _context.HotelOwners.Remove(hotelOwner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelOwnerExists(int id)
        {
            return (_context.HotelOwners?.Any(e => e.OwnerId == id)).GetValueOrDefault();
        }
    }
}
