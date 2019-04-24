using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;

namespace WebApp.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongChordsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public SongChordsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/SongChords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongChord>>> GetSongChords()
        {
            return Ok(await _bll.SongChords.AllAsyncWithInclude());
        }

        // GET: api/SongChords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SongChord>> GetSongChord(int id)
        {
            var songChord = await _bll.SongChords.FindAsync(id);

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

            _bll.SongChords.Update(songChord);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/SongChords
        [HttpPost]
        public async Task<ActionResult<SongChord>> PostSongChord(SongChord songChord)
        {
            await _bll.SongChords.AddAsync(songChord);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetSongChord", new { id = songChord.Id }, songChord);
        }

        // DELETE: api/SongChords/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SongChord>> DeleteSongChord(int id)
        {
            var songChord = await _bll.SongChords.FindAsync(id);
            if (songChord == null)
            {
                return NotFound();
            }

            _bll.SongChords.Remove(songChord);
            await _bll.SaveChangesAsync();

            return songChord;
        }
    }
}
