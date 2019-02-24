using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TuningNotesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TuningNotesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TuningNotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TuningNote>>> GetTuningNotes()
        {
            return await _context.TuningNotes.ToListAsync();
        }

        // GET: api/TuningNotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TuningNote>> GetTuningNote(int id)
        {
            var tuningNote = await _context.TuningNotes.FindAsync(id);

            if (tuningNote == null)
            {
                return NotFound();
            }

            return tuningNote;
        }

        // PUT: api/TuningNotes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTuningNote(int id, TuningNote tuningNote)
        {
            if (id != tuningNote.TuningNoteId)
            {
                return BadRequest();
            }

            _context.Entry(tuningNote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TuningNoteExists(id))
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

        // POST: api/TuningNotes
        [HttpPost]
        public async Task<ActionResult<TuningNote>> PostTuningNote(TuningNote tuningNote)
        {
            _context.TuningNotes.Add(tuningNote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTuningNote", new { id = tuningNote.TuningNoteId }, tuningNote);
        }

        // DELETE: api/TuningNotes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TuningNote>> DeleteTuningNote(int id)
        {
            var tuningNote = await _context.TuningNotes.FindAsync(id);
            if (tuningNote == null)
            {
                return NotFound();
            }

            _context.TuningNotes.Remove(tuningNote);
            await _context.SaveChangesAsync();

            return tuningNote;
        }

        private bool TuningNoteExists(int id)
        {
            return _context.TuningNotes.Any(e => e.TuningNoteId == id);
        }
    }
}
