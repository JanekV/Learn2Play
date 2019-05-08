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
            return (await _bll.TuningNotes.AllAsyncWithInclude())
                .Select(PublicApi.v1.Mappers.TuningNoteMapper.MapFromBLL).ToList();
        }

        // GET: api/TuningNotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.TuningNote>> GetTuningNote(int id)
        {
            var tuningNote = PublicApi.v1.Mappers.TuningNoteMapper.MapFromBLL(await _bll.TuningNotes.FindAsync(id));

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

            _bll.TuningNotes.Update(PublicApi.v1.Mappers.TuningNoteMapper.MapFromExternal(tuningNote));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/TuningNotes
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.TuningNote>> PostTuningNote(PublicApi.v1.DTO.DomainEntityDTOs.TuningNote tuningNote)
        {
            await _bll.TuningNotes.AddAsync(PublicApi.v1.Mappers.TuningNoteMapper.MapFromExternal(tuningNote));
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

            _bll.TuningNotes.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
