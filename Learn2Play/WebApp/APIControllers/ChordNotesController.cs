using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly AppDbContext _context;

        public ChordNotesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ChordNotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChordNote>>> GetChordNotes()
        {
            return await _context.ChordNotes.ToListAsync();
        }

        // GET: api/ChordNotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChordNote>> GetChordNote(int id)
        {
            var chordNote = await _context.ChordNotes.FindAsync(id);

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
            if (id != chordNote.ChordNoteId)
            {
                return BadRequest();
            }

            _context.Entry(chordNote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChordNoteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ChordNotes
        [HttpPost]
        public async Task<ActionResult<ChordNote>> PostChordNote(ChordNote chordNote)
        {
            _context.ChordNotes.Add(chordNote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChordNote", new { id = chordNote.ChordNoteId }, chordNote);
        }

        // DELETE: api/ChordNotes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ChordNote>> DeleteChordNote(int id)
        {
            var chordNote = await _context.ChordNotes.FindAsync(id);
            if (chordNote == null)
            {
                return NotFound();
            }

            _context.ChordNotes.Remove(chordNote);
            await _context.SaveChangesAsync();

            return chordNote;
        }

        private bool ChordNoteExists(int id)
        {
            return _context.ChordNotes.Any(e => e.ChordNoteId == id);
        }
    }
}
