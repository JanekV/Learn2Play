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
    public class TuningNotesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public TuningNotesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/TuningNotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.TuningNote>>> GetTuningNotes()
        {
            return Ok(await _bll.TuningNotes.AllAsyncWithInclude());
        }

        // GET: api/TuningNotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.TuningNote>> GetTuningNote(int id)
        {
            var tuningNote = await _bll.TuningNotes.FindAsync(id);

            if (tuningNote == null)
            {
                return NotFound();
            }

            return tuningNote;
        }

        // PUT: api/TuningNotes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTuningNote(int id, PublicApi.v1.DTO.DomainEntityDTOs.TuningNote tuningNote)
        {
            if (id != tuningNote.Id)
            {
                return BadRequest();
            }

            _bll.TuningNotes.Update(tuningNote);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/TuningNotes
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.TuningNote>> PostTuningNote(PublicApi.v1.DTO.DomainEntityDTOs.TuningNote tuningNote)
        {
            await _bll.TuningNotes.AddAsync(tuningNote);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetTuningNote", new { id = tuningNote.Id }, tuningNote);
        }

        // DELETE: api/TuningNotes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.TuningNote>> DeleteTuningNote(int id)
        {
            var tuningNote = await _bll.TuningNotes.FindAsync(id);
            if (tuningNote == null)
            {
                return NotFound();
            }

            _bll.TuningNotes.Remove(tuningNote);
            await _bll.SaveChangesAsync();

            return tuningNote;
        }
    }
}
