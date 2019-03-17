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
    public class SongStylesController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public SongStylesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/SongStyles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongStyle>>> GetSongStyles()
        {
            return Ok(await _uow.SongStyles.AllAsyncWithInclude());
        }

        // GET: api/SongStyles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SongStyle>> GetSongStyle(int id)
        {
            var songStyle = await _uow.SongStyles.FindAsync(id);

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
            if (id != songStyle.Id)
            {
                return BadRequest();
            }

            _uow.SongStyles.Update(songStyle);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/SongStyles
        [HttpPost]
        public async Task<ActionResult<SongStyle>> PostSongStyle(SongStyle songStyle)
        {
            await _uow.SongStyles.AddAsync(songStyle);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetSongStyle", new { id = songStyle.Id }, songStyle);
        }

        // DELETE: api/SongStyles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SongStyle>> DeleteSongStyle(int id)
        {
            var songStyle = await _uow.SongStyles.FindAsync(id);
            if (songStyle == null)
            {
                return NotFound();
            }

            _uow.SongStyles.Remove(songStyle);
            await _uow.SaveChangesAsync();

            return songStyle;
        }
    }
}
