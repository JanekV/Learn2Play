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
    public class SongsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public SongsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Songs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.Song>>> GetSongs()
        {
            return Ok(await _bll.Songs.AllAsyncWithInclude());
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Song>> GetSong(int id)
        {
            var song = await _bll.Songs.FindAsync(id);

            if (song == null)
            {
                return NotFound();
            }

            return song;
        }

        // PUT: api/Songs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSong(int id, PublicApi.v1.DTO.DomainEntityDTOs.Song song)
        {
            if (id != song.Id)
            {
                return BadRequest();
            }

            _bll.Songs.Update(song);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Songs
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Song>> PostSong(PublicApi.v1.DTO.DomainEntityDTOs.Song song)
        {
            await _bll.Songs.AddAsync(song);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetSong", new { id = song.Id }, song);
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Song>> DeleteSong(int id)
        {
            var song = await _bll.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            _bll.Songs.Remove(song);
            await _bll.SaveChangesAsync();

            return song;
        }
    }
}
