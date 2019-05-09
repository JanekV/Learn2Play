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
    public class SongStylesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public SongStylesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/SongStyles
        /// <summary>
        /// Get all SongStyle objects
        /// </summary>
        /// <returns>Array of all SongStyles.</returns>
        /// <response code="200">The array of SongStyles was successfully retrieved.</response>
        [ProducesResponseType(typeof(IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.SongStyle>),
            StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.SongStyle>>> GetSongStyles()
        {
            return (await _bll.SongStyles.AllAsyncWithInclude())
                .Select(PublicApi.v1.Mappers.SongStyleMapper.MapFromBLL).ToList();
        }

        // GET: api/SongStyles/5
        /// <summary>
        /// Get a SongStyle object by id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>SongStyle object with given id.</returns>
        /// <response code="200">SongStyle was successfully retrieved.</response>
        /// <response code="404">SongStyle was not found.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.DomainEntityDTOs.SongStyle),
            StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.SongStyle>> GetSongStyle(int id)
        {
            var songStyle = PublicApi.v1.Mappers.SongStyleMapper.MapFromBLL(await _bll.SongStyles.FindAsync(id));

            if (songStyle == null)
            {
                return NotFound();
            }

            return songStyle;
        }

        // PUT: api/SongStyles/5
        /// <summary>
        /// Update a SongStyle object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <param name="songStyle">PublicApi.v1.DTO.DomainEntityDTOs.SongStyle type object.</param>
        /// <returns>NoContent();</returns>:TODO Add a better description!
        /// <response code="204">SongStyle was successfully retrieved.</response>
        /// <response code="400">SongStyle was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongStyle(int id, PublicApi.v1.DTO.DomainEntityDTOs.SongStyle songStyle)
        {
            if (id != songStyle.Id)
            {
                return BadRequest();
            }

            _bll.SongStyles.Update(PublicApi.v1.Mappers.SongStyleMapper.MapFromExternal(songStyle));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/SongStyles
        /// <summary>
        /// Create and post a new SongStyle object.
        /// </summary>
        /// <param name="songStyle">PublicApi.v1.DTO.DomainEntityDTOs.SongStyle type object.</param>
        /// <returns>CreatedAtAction();</returns>:TODO Add a better description!
        /// <response code="201">SongStyle was successfully created.</response>
        /// <response code="400">SongStyle was not created.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.SongStyle>> PostSongStyle(PublicApi.v1.DTO.DomainEntityDTOs.SongStyle songStyle)
        {
            await _bll.SongStyles.AddAsync(PublicApi.v1.Mappers.SongStyleMapper.MapFromExternal(songStyle));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetSongStyle", new { id = songStyle.Id }, songStyle);
        }

        // DELETE: api/SongStyles/5
        /// <summary>
        /// Delete a SongStyle object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>NoContent();</returns>
        /// <response code="204">SongStyle with given id was successfully deleted.</response>
        /// <response code="404">SongStyle with given id was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.SongStyle>> DeleteSongStyle(int id)
        {
            var songStyle = await _bll.SongStyles.FindAsync(id);
            if (songStyle == null)
            {
                return NotFound();
            }

            _bll.SongStyles.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
