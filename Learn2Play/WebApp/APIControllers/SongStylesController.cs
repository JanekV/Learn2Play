using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongStylesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SongStylesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/SongStyles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongStyle>>> GetSongStyles()
        {
            return await _context.SongStyles.ToListAsync();
        }

        // GET: api/SongStyles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SongStyle>> GetSongStyle(int id)
        {
            var songStyle = await _context.SongStyles.FindAsync(id);

            if (songStyle == null)
            {
                return NotFound();
            }

            return songStyle;
        }

        // PUT: api/SongStyles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongStyle(int id, SongStyle songStyle)
        {
            if (id != songStyle.SongStyleId)
            {
                return BadRequest();
            }

            _context.Entry(songStyle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongStyleExists(id))
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

        // POST: api/SongStyles
        [HttpPost]
        public async Task<ActionResult<SongStyle>> PostSongStyle(SongStyle songStyle)
        {
            _context.SongStyles.Add(songStyle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSongStyle", new { id = songStyle.SongStyleId }, songStyle);
        }

        // DELETE: api/SongStyles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SongStyle>> DeleteSongStyle(int id)
        {
            var songStyle = await _context.SongStyles.FindAsync(id);
            if (songStyle == null)
            {
                return NotFound();
            }

            _context.SongStyles.Remove(songStyle);
            await _context.SaveChangesAsync();

            return songStyle;
        }

        private bool SongStyleExists(int id)
        {
            return _context.SongStyles.Any(e => e.SongStyleId == id);
        }
    }
}
