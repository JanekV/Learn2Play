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
    public class SongsController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public SongsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Songs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            return Ok(await _uow.Songs.AllAsyncWithInclude());
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSong(int id)
        {
            var song = await _uow.Songs.FindAsync(id);

            if (song == null)
            {
                return NotFound();
            }

            return song;
        }

        // PUT: api/Songs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSong(int id, Song song)
        {
            if (id != song.Id)
            {
                return BadRequest();
            }

            _uow.Songs.Update(song);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Songs
        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
            await _uow.Songs.AddAsync(song);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetSong", new { id = song.Id }, song);
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Song>> DeleteSong(int id)
        {
            var song = await _uow.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            _uow.Songs.Remove(song);
            await _uow.SaveChangesAsync();

            return song;
        }
    }
}
