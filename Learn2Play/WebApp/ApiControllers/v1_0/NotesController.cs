using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.v1_0
{
    [Authorize(Roles = "DbAdmin")]
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
        /// <summary>
        /// Get all Note objects
        /// </summary>
        /// <returns>Array of all Notes.</returns>
        /// <response code="200">The array of Notes was successfully retrieved.</response>
        [ProducesResponseType(typeof(IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.Note>),
            StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.Note>>> GetNotes()
        {
            return (await _bll.Notes.AllAsync())
                .Select(PublicApi.v1.Mappers.NoteMapper.MapFromBLL).ToList();
        }

        // GET: api/Notes/5
        /// <summary>
        /// Get a Note object by id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>Note object with given id.</returns>
        /// <response code="200">Note was successfully retrieved.</response>
        /// <response code="404">Note was not found.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.DomainEntityDTOs.Note),
            StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        /// <summary>
        /// Update a Note object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <param name="note">PublicApi.v1.DTO.DomainEntityDTOs.Note type object.</param>
        /// <returns>NoContent();</returns>:TODO Add a better description!
        /// <response code="204">Note was successfully retrieved.</response>
        /// <response code="400">Note was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        /// <summary>
        /// Create and post a new Note object.
        /// </summary>
        /// <param name="note">PublicApi.v1.DTO.DomainEntityDTOs.Note type object.</param>
        /// <returns>CreatedAtAction();</returns>:TODO Add a better description!
        /// <response code="201">Note was successfully created.</response>
        /// <response code="400">Note was not created.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Note>> PostNote(PublicApi.v1.DTO.DomainEntityDTOs.Note note)
        {
            await _bll.Notes.AddAsync(PublicApi.v1.Mappers.NoteMapper.MapFromExternal(note));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetNote", new { id = note.Id }, note);
        }

        // DELETE: api/Notes/5
        /// <summary>
        /// Delete a Note object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>NoContent();</returns>
        /// <response code="204">Note with given id was successfully deleted.</response>
        /// <response code="404">Note with given id was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
