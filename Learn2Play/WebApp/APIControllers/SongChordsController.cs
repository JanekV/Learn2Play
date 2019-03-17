using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
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
        private readonly IAppUnitOfWork _uow;

        public SongChordsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/SongChords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongChord>>> GetSongChords()
        {
            return Ok(await _uow.SongChords.AllAsyncWithInclude());
        }

        // GET: api/SongChords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SongChord>> GetSongChord(int id)
        {
            var songChord = await _uow.SongChords.FindAsync(id);

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
            if (id != songChord.Id)
            {
                return BadRequest();
            }

            _uow.SongChords.Update(songChord);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/SongChords
        [HttpPost]
        public async Task<ActionResult<SongChord>> PostSongChord(SongChord songChord)
        {
            await _uow.SongChords.AddAsync(songChord);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetSongChord", new { id = songChord.Id }, songChord);
        }

        // DELETE: api/SongChords/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SongChord>> DeleteSongChord(int id)
        {
            var songChord = await _uow.SongChords.FindAsync(id);
            if (songChord == null)
            {
                return NotFound();
            }

            _uow.SongChords.Remove(songChord);
            await _uow.SaveChangesAsync();

            return songChord;
        }
    }
}
