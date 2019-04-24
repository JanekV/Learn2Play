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
    public class ChordsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public ChordsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Chords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chord>>> GetChords()
        {
            return Ok(await _bll.Chords.AllAsync());
        }

        // GET: api/Chords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chord>> GetChord(int id)
        {
            var chord = await _bll.Chords.FindAsync(id);

            if (chord == null)
            {
                return NotFound();
            }

            return chord;
        }

        // PUT: api/Chords/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChord(int id, Chord chord)
        {
            if (id != chord.Id)
            {
                return BadRequest();
            }

            _bll.Chords.Update(chord);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Chords
        [HttpPost]
        public async Task<ActionResult<Chord>> PostChord(Chord chord)
        {
            await _bll.Chords.AddAsync(chord);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetChord", new { id = chord.Id }, chord);
        }

        // DELETE: api/Chords/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Chord>> DeleteChord(int id)
        {
            var chord = await _bll.Chords.FindAsync(id);
            if (chord == null)
            {
                return NotFound();
            }

            _bll.Chords.Remove(chord);
            await _bll.SaveChangesAsync();

            return chord;
        }
    }
}
