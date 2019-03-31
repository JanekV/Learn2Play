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
    public class TuningNotesController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public TuningNotesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/TuningNotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TuningNote>>> GetTuningNotes()
        {
            return Ok(await _uow.TuningNotes.AllAsyncWithInclude());
        }

        // GET: api/TuningNotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TuningNote>> GetTuningNote(int id)
        {
            var tuningNote = await _uow.TuningNotes.FindAsync(id);

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
            if (id != tuningNote.Id)
            {
                return BadRequest();
            }

            _uow.TuningNotes.Update(tuningNote);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/TuningNotes
        [HttpPost]
        public async Task<ActionResult<TuningNote>> PostTuningNote(TuningNote tuningNote)
        {
            await _uow.TuningNotes.AddAsync(tuningNote);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetTuningNote", new { id = tuningNote.Id }, tuningNote);
        }

        // DELETE: api/TuningNotes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TuningNote>> DeleteTuningNote(int id)
        {
            var tuningNote = await _uow.TuningNotes.FindAsync(id);
            if (tuningNote == null)
            {
                return NotFound();
            }

            _uow.TuningNotes.Remove(tuningNote);
            await _uow.SaveChangesAsync();

            return tuningNote;
        }
    }
}
