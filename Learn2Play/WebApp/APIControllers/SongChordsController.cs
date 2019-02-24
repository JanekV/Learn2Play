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
    public class SongChordsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SongChordsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/SongChords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongChord>>> GetSongChords()
        {
            return await _context.SongChords.ToListAsync();
        }

        // GET: api/SongChords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SongChord>> GetSongChord(int id)
        {
            var songChord = await _context.SongChords.FindAsync(id);

            if (songChord == null)
            {
                return NotFound();
            }

            return songChord;
        }

        // PUT: api/SongChords/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongChord(int id, SongChord songChord)
        {
            if (id != songChord.SongChordId)
            {
                return BadRequest();
            }

            _context.Entry(songChord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongChordExists(id))
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

        // POST: api/SongChords
        [HttpPost]
        public async Task<ActionResult<SongChord>> PostSongChord(SongChord songChord)
        {
            _context.SongChords.Add(songChord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSongChord", new { id = songChord.SongChordId }, songChord);
        }

        // DELETE: api/SongChords/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SongChord>> DeleteSongChord(int id)
        {
            var songChord = await _context.SongChords.FindAsync(id);
            if (songChord == null)
            {
                return NotFound();
            }

            _context.SongChords.Remove(songChord);
            await _context.SaveChangesAsync();

            return songChord;
        }

        private bool SongChordExists(int id)
        {
            return _context.SongChords.Any(e => e.SongChordId == id);
        }
    }
}
