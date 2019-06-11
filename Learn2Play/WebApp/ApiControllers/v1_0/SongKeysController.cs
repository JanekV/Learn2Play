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
    public class SongKeysController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public SongKeysController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/SongKeys
        /// <summary>
        /// Get all SongKey objects
        /// </summary>
        /// <returns>Array of all SongKeys.</returns>
        /// <response code="200">The array of SongKeys was successfully retrieved.</response>
        [ProducesResponseType(typeof(IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.SongKey>),
            StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.SongKey>>> GetSongKeys()
        {
            return (await _bll.SongKeys.AllAsyncWithInclude())
                .Select(PublicApi.v1.Mappers.SongKeyMapper.MapFromBLL).ToList();
        }

        // GET: api/SongKeys/5
        /// <summary>
        /// Get a SongKey object by id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>SongKey object with given id.</returns>
        /// <response code="200">SongKey was successfully retrieved.</response>
        /// <response code="404">SongKey was not found.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.DomainEntityDTOs.SongKey),
            StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.SongKey>> GetSongKey(int id)
        {
            var songKey = PublicApi.v1.Mappers.SongKeyMapper.MapFromBLL(await _bll.SongKeys.FindAsync(id));

            if (songKey == null)
            {
                return NotFound();
            }

            return songKey;
        }

        // PUT: api/SongKeys/5
        /// <summary>
        /// Update a SongKey object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <param name="songKey">PublicApi.v1.DTO.DomainEntityDTOs.SongKey type object.</param>
        /// <returns>NoContent();</returns>:TODO Add a better description!
        /// <response code="204">SongKey was successfully retrieved.</response>
        /// <response code="400">SongKey was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongKey(int id, PublicApi.v1.DTO.DomainEntityDTOs.SongKey songKey)
        {
            if (id != songKey.Id)
            {
                return BadRequest();
            }

            _bll.SongKeys.Update(PublicApi.v1.Mappers.SongKeyMapper.MapFromExternal(songKey));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/SongKeys
        /// <summary>
        /// Create and post a new SongKey object.
        /// </summary>
        /// <param name="songKey">PublicApi.v1.DTO.DomainEntityDTOs.SongKey type object.</param>
        /// <returns>CreatedAtAction();</returns>:TODO Add a better description!
        /// <response code="201">SongKey was successfully created.</response>
        /// <response code="400">SongKey was not created.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.SongKey>> PostSongKey(PublicApi.v1.DTO.DomainEntityDTOs.SongKey songKey)
        {
            await _bll.SongKeys.AddAsync(PublicApi.v1.Mappers.SongKeyMapper.MapFromExternal(songKey));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetSongKey", new { id = songKey.Id }, songKey);
        }

        // DELETE: api/SongKeys/5
        /// <summary>
        /// Delete a SongKey object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>NoContent();</returns>
        /// <response code="204">SongKey with given id was successfully deleted.</response>
        /// <response code="404">SongKey with given id was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.SongKey>> DeleteSongKey(int id)
        {
            var songKey = await _bll.SongKeys.FindAsync(id);
            if (songKey == null)
            {
                return NotFound();
            }

            _bll.SongKeys.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
