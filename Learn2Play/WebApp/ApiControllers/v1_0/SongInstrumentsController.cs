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
    public class SongInstrumentsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public SongInstrumentsController(IAppBLL bll)
        {
            _bll = bll;
        }


        // GET: api/SongInstruments
        /// <summary>
        /// Get all SongInstrument objects
        /// </summary>
        /// <returns>Array of all SongInstruments.</returns>
        /// <response code="200">The array of SongInstruments was successfully retrieved.</response>
        [ProducesResponseType(typeof(IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.SongInstrument>),
            StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.SongInstrument>>> GetSongInstruments()
        {
            return (await _bll.SongInstruments.AllAsyncWithInclude())
                .Select(PublicApi.v1.Mappers.SongInstrumentMapper.MapFromBLL).ToList();
        }

        // GET: api/SongInstruments/5
        /// <summary>
        /// Get a SongInstrument object by id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>SongInstrument object with given id.</returns>
        /// <response code="200">SongInstrument was successfully retrieved.</response>
        /// <response code="404">SongInstrument was not found.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.DomainEntityDTOs.SongInstrument),
            StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.SongInstrument>> GetSongInstrument(int id)
        {
            var songInstrument = PublicApi.v1.Mappers.SongInstrumentMapper.MapFromBLL(await _bll.SongInstruments.FindAsync(id));

            if (songInstrument == null)
            {
                return NotFound();
            }

            return songInstrument;
        }

        // PUT: api/SongInstruments/5
        /// <summary>
        /// Update a SongInstrument object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <param name="songInstrument">PublicApi.v1.DTO.DomainEntityDTOs.SongInstrument type object.</param>
        /// <returns>NoContent();</returns>:TODO Add a better description!
        /// <response code="204">SongInstrument was successfully retrieved.</response>
        /// <response code="400">SongInstrument was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongInstrument(int id, PublicApi.v1.DTO.DomainEntityDTOs.SongInstrument songInstrument)
        {
            if (id != songInstrument.Id)
            {
                return BadRequest();
            }

            _bll.SongInstruments.Update(PublicApi.v1.Mappers.SongInstrumentMapper.MapFromExternal(songInstrument));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/SongInstruments
        /// <summary>
        /// Create and post a new SongInstrument object.
        /// </summary>
        /// <param name="songInstrument">PublicApi.v1.DTO.DomainEntityDTOs.SongInstrument type object.</param>
        /// <returns>CreatedAtAction();</returns>:TODO Add a better description!
        /// <response code="201">SongInstrument was successfully created.</response>
        /// <response code="400">SongInstrument was not created.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.SongInstrument>> PostSongInstrument(PublicApi.v1.DTO.DomainEntityDTOs.SongInstrument songInstrument)
        {
            await _bll.SongInstruments.AddAsync(PublicApi.v1.Mappers.SongInstrumentMapper.MapFromExternal(songInstrument));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetSongInstrument", new { id = songInstrument.Id }, songInstrument);
        }

        // DELETE: api/SongInstruments/5
        /// <summary>
        /// Delete a SongInstrument object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>NoContent();</returns>
        /// <response code="204">SongInstrument with given id was successfully deleted.</response>
        /// <response code="404">SongInstrument with given id was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.SongInstrument>> DeleteSongInstrument(int id)
        {
            var songInstrument = await _bll.SongInstruments.FindAsync(id);
            if (songInstrument == null)
            {
                return NotFound();
            }

            _bll.SongInstruments.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
