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
    public class SongInstrumentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SongInstrumentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/SongInstruments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongInstrument>>> GetSongInstruments()
        {
            return await _context.SongInstruments.ToListAsync();
        }

        // GET: api/SongInstruments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SongInstrument>> GetSongInstrument(int id)
        {
            var songInstrument = await _context.SongInstruments.FindAsync(id);

            if (songInstrument == null)
            {
                return NotFound();
            }

            return songInstrument;
        }

        // PUT: api/SongInstruments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongInstrument(int id, SongInstrument songInstrument)
        {
            if (id != songInstrument.SongInstrumentId)
            {
                return BadRequest();
            }

            _context.Entry(songInstrument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongInstrumentExists(id))
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

        // POST: api/SongInstruments
        [HttpPost]
        public async Task<ActionResult<SongInstrument>> PostSongInstrument(SongInstrument songInstrument)
        {
            _context.SongInstruments.Add(songInstrument);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSongInstrument", new { id = songInstrument.SongInstrumentId }, songInstrument);
        }

        // DELETE: api/SongInstruments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SongInstrument>> DeleteSongInstrument(int id)
        {
            var songInstrument = await _context.SongInstruments.FindAsync(id);
            if (songInstrument == null)
            {
                return NotFound();
            }

            _context.SongInstruments.Remove(songInstrument);
            await _context.SaveChangesAsync();

            return songInstrument;
        }

        private bool SongInstrumentExists(int id)
        {
            return _context.SongInstruments.Any(e => e.SongInstrumentId == id);
        }
    }
}
