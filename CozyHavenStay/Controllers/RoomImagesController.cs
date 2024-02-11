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
    public class RoomImagesController : ControllerBase
    {
        private readonly CozyHavenStayContext _context;

        public RoomImagesController(CozyHavenStayContext context)
        {
            _context = context;
        }

        // GET: api/RoomImages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomImage>>> GetRoomImages()
        {
          if (_context.RoomImages == null)
          {
              return NotFound();
          }
            return await _context.RoomImages.ToListAsync();
        }

        // GET: api/RoomImages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomImage>> GetRoomImage(int id)
        {
          if (_context.RoomImages == null)
          {
              return NotFound();
          }
            var roomImage = await _context.RoomImages.FindAsync(id);

            if (roomImage == null)
            {
                return NotFound();
            }

            return roomImage;
        }

        // PUT: api/RoomImages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomImage(int id, RoomImage roomImage)
        {
            if (id != roomImage.ImageId)
            {
                return BadRequest();
            }

            _context.Entry(roomImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomImageExists(id))
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

        // POST: api/RoomImages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomImage>> PostRoomImage(RoomImage roomImage)
        {
          if (_context.RoomImages == null)
          {
              return Problem("Entity set 'CozyHavenStayContext.RoomImages'  is null.");
          }
            _context.RoomImages.Add(roomImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomImage", new { id = roomImage.ImageId }, roomImage);
        }

        // DELETE: api/RoomImages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomImage(int id)
        {
            if (_context.RoomImages == null)
            {
                return NotFound();
            }
            var roomImage = await _context.RoomImages.FindAsync(id);
            if (roomImage == null)
            {
                return NotFound();
            }

            _context.RoomImages.Remove(roomImage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomImageExists(int id)
        {
            return (_context.RoomImages?.Any(e => e.ImageId == id)).GetValueOrDefault();
        }
    }
}
