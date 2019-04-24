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
    public class SongKeysController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public SongKeysController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/SongKeys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongKey>>> GetSongKeys()
        {
            return Ok(await _bll.SongKeys.AllAsyncWithInclude());
        }

        // GET: api/SongKeys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SongKey>> GetSongKey(int id)
        {
            var songKey = await _bll.SongKeys.FindAsync(id);

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

            _bll.SongKeys.Update(songKey);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/SongKeys
        [HttpPost]
        public async Task<ActionResult<SongKey>> PostSongKey(SongKey songKey)
        {
            await _bll.SongKeys.AddAsync(songKey);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetSongKey", new { id = songKey.Id }, songKey);
        }

        // DELETE: api/SongKeys/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SongKey>> DeleteSongKey(int id)
        {
            var songKey = await _bll.SongKeys.FindAsync(id);
            if (songKey == null)
            {
                return NotFound();
            }

            _bll.SongKeys.Remove(songKey);
            await _bll.SaveChangesAsync();

            return songKey;
        }
    }
}
