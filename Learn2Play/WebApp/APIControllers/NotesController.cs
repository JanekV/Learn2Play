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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class NotesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public NotesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Notes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.Note>>> GetNotes()
        {
            return Ok(await _bll.Notes.AllAsync());
        }

        // GET: api/Notes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Note>> GetNote(int id)
        {
            var note = await _bll.Notes.FindAsync(id);

            if (note == null)
            {
                return NotFound();
            }

            return note;
        }

        // PUT: api/Notes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNote(int id, PublicApi.v1.DTO.DomainEntityDTOs.Note note)
        {
            if (id != note.Id)
            {
                return BadRequest();
            }

            _bll.Notes.Update(note);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Notes
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Note>> PostNote(PublicApi.v1.DTO.DomainEntityDTOs.Note note)
        {
            await _bll.Notes.AddAsync(note);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetNote", new { id = note.Id }, note);
        }

        // DELETE: api/Notes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Note>> DeleteNote(int id)
        {
            var note = await _bll.Notes.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }

            _bll.Notes.Remove(note);
            await _bll.SaveChangesAsync();

            return note;
        }
    }
}
