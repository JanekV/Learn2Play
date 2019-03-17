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
using Microsoft.AspNetCore.Authorization;

namespace WebApp.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChordNotesController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public ChordNotesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/ChordNotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChordNote>>> GetChordNotes()
        {
            return Ok(await _uow.ChordNotes.AllAsyncWithInclude());
        }

        // GET: api/ChordNotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChordNote>> GetChordNote(int id)
        {
            var chordNote = await _uow.ChordNotes.FindAsync(id);

            if (chordNote == null)
            {
                return NotFound();
            }

            return chordNote;
        }

        // PUT: api/ChordNotes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChordNote(int id, ChordNote chordNote)
        {
            if (id != chordNote.Id)
            {
                return BadRequest();
            }

            _uow.ChordNotes.Update(chordNote);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/ChordNotes
        [HttpPost]
        public async Task<ActionResult<ChordNote>> PostChordNote(ChordNote chordNote)
        {
            await _uow.ChordNotes.AddAsync(chordNote);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetChordNote", new { id = chordNote.Id }, chordNote);
        }

        // DELETE: api/ChordNotes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ChordNote>> DeleteChordNote(int id)
        {
            var chordNote = await _uow.ChordNotes.FindAsync(id);
            if (chordNote == null)
            {
                return NotFound();
            }

            _uow.ChordNotes.Remove(chordNote);
            await _uow.SaveChangesAsync();

            return chordNote;
        }
    }
}
