using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class SongKeysController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public SongKeysController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/SongKeys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongKey>>> GetSongKeys()
        {
            return Ok(await _uow.SongKeys.AllAsyncWithInclude());
        }

        // GET: api/SongKeys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SongKey>> GetSongKey(int id)
        {
            var songKey = await _uow.SongKeys.FindAsync(id);

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
            if (id != songKey.Id)
            {
                return BadRequest();
            }

            _uow.SongKeys.Update(songKey);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/SongKeys
        [HttpPost]
        public async Task<ActionResult<SongKey>> PostSongKey(SongKey songKey)
        {
            await _uow.SongKeys.AddAsync(songKey);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetSongKey", new { id = songKey.Id }, songKey);
        }

        // DELETE: api/SongKeys/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SongKey>> DeleteSongKey(int id)
        {
            var songKey = await _uow.SongKeys.FindAsync(id);
            if (songKey == null)
            {
                return NotFound();
            }

            _uow.SongKeys.Remove(songKey);
            await _uow.SaveChangesAsync();

            return songKey;
        }
    }
}
