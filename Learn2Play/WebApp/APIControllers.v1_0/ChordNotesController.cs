using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.APIControllers.v1_0
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ChordNotesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public ChordNotesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/ChordNotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.ChordNote>>> GetChordNotes()
        {
            return (await _bll.ChordNotes.AllAsyncWithInclude())
                .Select(PublicApi.v1.Mappers.ChordNoteMapper.MapFromBLL).ToList();
        }

        // GET: api/ChordNotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.ChordNote>> GetChordNote(int id)
        {
            var chordNote = PublicApi.v1.Mappers.ChordNoteMapper.MapFromBLL(await _bll.ChordNotes.FindAsync(id));

            if (chordNote == null)
            {
                return NotFound();
            }

            return chordNote;
        }

        // PUT: api/ChordNotes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChordNote(int id, PublicApi.v1.DTO.DomainEntityDTOs.ChordNote chordNote)
        {
            if (id != chordNote.Id)
            {
                return BadRequest();
            }

            _bll.ChordNotes.Update(PublicApi.v1.Mappers.ChordNoteMapper.MapFromExternal(chordNote));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/ChordNotes
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.ChordNote>> PostChordNote(PublicApi.v1.DTO.DomainEntityDTOs.ChordNote chordNote)
        {
            //:TODO Fix id problem!!!
            await _bll.ChordNotes.AddAsync(PublicApi.v1.Mappers.ChordNoteMapper.MapFromExternal(chordNote));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetChordNote", new { id = chordNote.Id }, chordNote);
        }

        // DELETE: api/ChordNotes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.ChordNote>> DeleteChordNote(int id)
        {
            var chordNote = await _bll.ChordNotes.FindAsync(id);
            if (chordNote == null)
            {
                return NotFound();
            }

            _bll.ChordNotes.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
