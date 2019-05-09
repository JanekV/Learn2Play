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
    public class SongChordsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public SongChordsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/SongChords
        /// <summary>
        /// Get all SongChord objects
        /// </summary>
        /// <returns>Array of all SongChords.</returns>
        /// <response code="200">The array of SongChords was successfully retrieved.</response>
        [ProducesResponseType(typeof(IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.SongChord>),
            StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.SongChord>>> GetSongChords()
        {
            return (await _bll.SongChords.AllAsyncWithInclude())
                .Select(PublicApi.v1.Mappers.SongChordMapper.MapFromBLL).ToList();
        }

        // GET: api/SongChords/5
        /// <summary>
        /// Get a SongChord object by id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>SongChord object with given id.</returns>
        /// <response code="200">SongChord was successfully retrieved.</response>
        /// <response code="404">SongChord was not found.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.DomainEntityDTOs.SongChord),
            StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.SongChord>> GetSongChord(int id)
        {
            var songChord = PublicApi.v1.Mappers.SongChordMapper.MapFromBLL(await _bll.SongChords.FindAsync(id));

            if (songChord == null)
            {
                return NotFound();
            }

            return songChord;
        }

        // PUT: api/SongChords/5
        /// <summary>
        /// Update a SongChord object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <param name="songChord">PublicApi.v1.DTO.DomainEntityDTOs.SongChord type object.</param>
        /// <returns>NoContent();</returns>:TODO Add a better description!
        /// <response code="204">SongChord was successfully retrieved.</response>
        /// <response code="400">SongChord was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongChord(int id, PublicApi.v1.DTO.DomainEntityDTOs.SongChord songChord)
        {
            if (id != songChord.Id)
            {
                return BadRequest();
            }

            _bll.SongChords.Update(PublicApi.v1.Mappers.SongChordMapper.MapFromExternal(songChord));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/SongChords
        /// <summary>
        /// Create and post a new SongChord object.
        /// </summary>
        /// <param name="songChord">PublicApi.v1.DTO.DomainEntityDTOs.SongChord type object.</param>
        /// <returns>CreatedAtAction();</returns>:TODO Add a better description!
        /// <response code="201">SongChord was successfully created.</response>
        /// <response code="400">SongChord was not created.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.SongChord>> PostSongChord(PublicApi.v1.DTO.DomainEntityDTOs.SongChord songChord)
        {
            await _bll.SongChords.AddAsync(PublicApi.v1.Mappers.SongChordMapper.MapFromExternal(songChord));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetSongChord", new { id = songChord.Id }, songChord);
        }

        // DELETE: api/SongChords/5
        /// <summary>
        /// Delete a SongChord object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>NoContent();</returns>
        /// <response code="204">SongChord with given id was successfully deleted.</response>
        /// <response code="404">SongChord with given id was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.SongChord>> DeleteSongChord(int id)
        {
            var songChord = await _bll.SongChords.FindAsync(id);
            if (songChord == null)
            {
                return NotFound();
            }

            _bll.SongChords.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
