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
    public class SongKeysController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SongKeysController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/SongKeys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongKey>>> GetSongKeys()
        {
            return await _context.SongKeys.ToListAsync();
        }

        // GET: api/SongKeys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SongKey>> GetSongKey(int id)
        {
            var songKey = await _context.SongKeys.FindAsync(id);

            if (songKey == null)
            {
                return NotFound();
            }

            return songKey;
        }

        // PUT: api/SongKeys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongKey(int id, SongKey songKey)
        {
            if (id != songKey.SongKeyId)
            {
                return BadRequest();
            }

            _context.Entry(songKey).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongKeyExists(id))
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

        // POST: api/SongKeys
        [HttpPost]
        public async Task<ActionResult<SongKey>> PostSongKey(SongKey songKey)
        {
            _context.SongKeys.Add(songKey);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSongKey", new { id = songKey.SongKeyId }, songKey);
        }

        // DELETE: api/SongKeys/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SongKey>> DeleteSongKey(int id)
        {
            var songKey = await _context.SongKeys.FindAsync(id);
            if (songKey == null)
            {
                return NotFound();
            }

            _context.SongKeys.Remove(songKey);
            await _context.SaveChangesAsync();

            return songKey;
        }

        private bool SongKeyExists(int id)
        {
            return _context.SongKeys.Any(e => e.SongKeyId == id);
        }
    }
}
