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
    public class SongInstrumentsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public SongInstrumentsController(IAppBLL bll)
        {
            _bll = bll;
        }


        // GET: api/SongInstruments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongInstrument>>> GetSongInstruments()
        {
            return Ok(await _bll.SongInstruments.AllAsyncWithInclude());
        }

        // GET: api/SongInstruments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SongInstrument>> GetSongInstrument(int id)
        {
            var songInstrument = await _bll.SongInstruments.FindAsync(id);

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
            if (id != songInstrument.Id)
            {
                return BadRequest();
            }

            _bll.SongInstruments.Update(songInstrument);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/SongInstruments
        [HttpPost]
        public async Task<ActionResult<SongInstrument>> PostSongInstrument(SongInstrument songInstrument)
        {
            await _bll.SongInstruments.AddAsync(songInstrument);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetSongInstrument", new { id = songInstrument.Id }, songInstrument);
        }

        // DELETE: api/SongInstruments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SongInstrument>> DeleteSongInstrument(int id)
        {
            var songInstrument = await _bll.SongInstruments.FindAsync(id);
            if (songInstrument == null)
            {
                return NotFound();
            }

            _bll.SongInstruments.Remove(songInstrument);
            await _bll.SaveChangesAsync();

            return songInstrument;
        }
    }
}
