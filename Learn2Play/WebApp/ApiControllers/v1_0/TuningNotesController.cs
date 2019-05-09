using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.v1_0
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
        /// <summary>
        /// Get all TuningNote objects
        /// </summary>
        /// <returns>Array of all TuningNotes.</returns>
        /// <response code="200">The array of TuningNotes was successfully retrieved.</response>
        [ProducesResponseType(typeof(IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.TuningNote>),
            StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.TuningNote>>> GetTuningNotes()
        {
            return (await _bll.TuningNotes.AllAsyncWithInclude())
                .Select(PublicApi.v1.Mappers.TuningNoteMapper.MapFromBLL).ToList();
        }

        // GET: api/TuningNotes/5
        /// <summary>
        /// Get a TuningNote object by id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>TuningNote object with given id.</returns>
        /// <response code="200">TuningNote was successfully retrieved.</response>
        /// <response code="404">TuningNote was not found.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.DomainEntityDTOs.TuningNote),
            StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        /// <summary>
        /// Update a TuningNote object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <param name="tuningNote">PublicApi.v1.DTO.DomainEntityDTOs.TuningNote type object.</param>
        /// <returns>NoContent();</returns>:TODO Add a better description!
        /// <response code="204">TuningNote was successfully retrieved.</response>
        /// <response code="400">TuningNote was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        /// <summary>
        /// Create and post a new TuningNote object.
        /// </summary>
        /// <param name="tuningNote">PublicApi.v1.DTO.DomainEntityDTOs.TuningNote type object.</param>
        /// <returns>CreatedAtAction();</returns>:TODO Add a better description!
        /// <response code="201">TuningNote was successfully created.</response>
        /// <response code="400">TuningNote was not created.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.TuningNote>> PostTuningNote(PublicApi.v1.DTO.DomainEntityDTOs.TuningNote tuningNote)
        {
            await _bll.TuningNotes.AddAsync(PublicApi.v1.Mappers.TuningNoteMapper.MapFromExternal(tuningNote));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetTuningNote", new { id = tuningNote.Id }, tuningNote);
        }

        // DELETE: api/TuningNotes/5
        /// <summary>
        /// Delete a TuningNote object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>NoContent();</returns>
        /// <response code="204">TuningNote with given id was successfully deleted.</response>
        /// <response code="404">TuningNote with given id was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
