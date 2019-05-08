using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.APIControllers.v1_0
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
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
            return (await _bll.Notes.AllAsync())
                .Select(PublicApi.v1.Mappers.NoteMapper.MapFromBLL).ToList();
        }

        // GET: api/Notes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Note>> GetNote(int id)
        {
            var note = PublicApi.v1.Mappers.NoteMapper.MapFromBLL(await _bll.Notes.FindAsync(id));

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

            _bll.Notes.Update(PublicApi.v1.Mappers.NoteMapper.MapFromExternal(note));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Notes
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Note>> PostNote(PublicApi.v1.DTO.DomainEntityDTOs.Note note)
        {
            await _bll.Notes.AddAsync(PublicApi.v1.Mappers.NoteMapper.MapFromExternal(note));
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

            _bll.Notes.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
