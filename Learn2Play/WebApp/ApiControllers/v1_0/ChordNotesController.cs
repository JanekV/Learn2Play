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
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ChordNotesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public ChordNotesController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get all ChordNote objects
        /// </summary>
        /// <returns>Array of all ChordNotes.</returns>
        /// <response code="200">The array of ChordNotes was successfully retrieved.</response>
        [ProducesResponseType(typeof(IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.ChordNote>),
            StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.ChordNote>>> GetChordNotes()
        {
            return (await _bll.ChordNotes.AllAsyncWithInclude())
                .Select(PublicApi.v1.Mappers.ChordNoteMapper.MapFromBLL).ToList();
        }

        /// <summary>
        /// Get a ChordNote object by id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>ChordNote object with given id.</returns>
        /// <response code="200">ChordNote was successfully retrieved.</response>
        /// <response code="404">ChordNote was not found.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.DomainEntityDTOs.ChordNote),
            StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// Update a ChordNote object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <param name="chordNote">PublicApi.v1.DTO.DomainEntityDTOs.ChordNote type object.</param>
        /// <returns>NoContent();</returns>:TODO Add a better description!
        /// <response code="204">ChordNote was successfully retrieved.</response>
        /// <response code="400">ChordNote was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        /// <summary>
        /// Create and post a new ChordNote object.
        /// </summary>
        /// <param name="chordNote">PublicApi.v1.DTO.DomainEntityDTOs.ChordNote type object.</param>
        /// <returns>CreatedAtAction();</returns>:TODO Add a better description!
        /// <response code="201">ChordNote was successfully created.</response>
        /// <response code="400">ChordNote was not created.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.ChordNote>> PostChordNote(PublicApi.v1.DTO.DomainEntityDTOs.ChordNote chordNote)
        {
            //:TODO Fix id problem!!!
            await _bll.ChordNotes.AddAsync(PublicApi.v1.Mappers.ChordNoteMapper.MapFromExternal(chordNote));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetChordNote", new { id = chordNote.Id }, chordNote);
        }

        /// <summary>
        /// Delete a ChordNote object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>NoContent();</returns>
        /// <response code="204">ChordNote with given id was successfully deleted.</response>
        /// <response code="404">ChordNote with given id was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
