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
    public class ChordsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public ChordsController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get all Chord objects
        /// </summary>
        /// <returns>Array of all Chords.</returns>
        /// <response code="200">The array of Chords was successfully retrieved.</response>
        [ProducesResponseType(typeof(IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.Chord>),
            StatusCodes.Status200OK)]        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.Chord>>> GetChords()
        {
            return (await _bll.Chords.AllAsync())
                .Select(PublicApi.v1.Mappers.ChordMapper.MapFromBLL).ToList();
        }

        /// <summary>
        /// Get a Chord object by id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>Chord object with given id.</returns>
        /// <response code="200">Chord was successfully retrieved.</response>
        /// <response code="404">Chord was not found.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.DomainEntityDTOs.Chord),
            StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Chord>> GetChord(int id)
        {
            var chord = PublicApi.v1.Mappers.ChordMapper.MapFromBLL(await _bll.Chords.FindAsync(id));

            if (chord == null)
            {
                return NotFound();
            }

            return chord;
        }

        /// <summary>
        /// Update a Chord object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <param name="chord">PublicApi.v1.DTO.DomainEntityDTOs.Chord type object.</param>
        /// <returns>NoContent();</returns>:TODO Add a better description!
        /// <response code="204">Chord was successfully retrieved.</response>
        /// <response code="400">Chord was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChord(int id, PublicApi.v1.DTO.DomainEntityDTOs.Chord chord)
        {
            if (id != chord.Id)
            {
                return BadRequest();
            }

            _bll.Chords.Update(PublicApi.v1.Mappers.ChordMapper.MapFromExternal(chord));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Create and post a new Chord object.
        /// </summary>
        /// <param name="chord">PublicApi.v1.DTO.DomainEntityDTOs.Chord type object.</param>
        /// <returns>CreatedAtAction();</returns>:TODO Add a better description!
        /// <response code="201">Chord was successfully created.</response>
        /// <response code="400">Chord was not created.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]        
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Chord>> PostChord(PublicApi.v1.DTO.DomainEntityDTOs.Chord chord)
        {
            await _bll.Chords.AddAsync(PublicApi.v1.Mappers.ChordMapper.MapFromExternal(chord));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetChord", new { id = chord.Id }, chord);
        }

        /// <summary>
        /// Delete a Chord object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>NoContent();</returns>
        /// <response code="204">Chord with given id was successfully deleted.</response>
        /// <response code="404">Chord with given id was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Chord>> DeleteChord(int id)
        {
            var chord = await _bll.Chords.FindAsync(id);
            if (chord == null)
            {
                return NotFound();
            }

            _bll.Chords.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
