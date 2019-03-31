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
    public class ChordsController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public ChordsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Chords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chord>>> GetChords()
        {
            return Ok(await _uow.Chords.AllAsync());
        }

        // GET: api/Chords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chord>> GetChord(int id)
        {
            var chord = await _uow.Chords.FindAsync(id);

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

            _uow.Chords.Update(chord);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Chords
        [HttpPost]
        public async Task<ActionResult<Chord>> PostChord(Chord chord)
        {
            await _uow.Chords.AddAsync(chord);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetChord", new { id = chord.Id }, chord);
        }

        // DELETE: api/Chords/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Chord>> DeleteChord(int id)
        {
            var chord = await _uow.Chords.FindAsync(id);
            if (chord == null)
            {
                return NotFound();
            }

            _uow.Chords.Remove(chord);
            await _uow.SaveChangesAsync();

            return chord;
        }
    }
}
