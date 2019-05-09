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
    public class VideosController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public VideosController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Videos
        /// <summary>
        /// Get all Video objects
        /// </summary>
        /// <returns>Array of all Videos.</returns>
        /// <response code="200">The array of Videos was successfully retrieved.</response>
        [ProducesResponseType(typeof(IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.Video>),
            StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.Video>>> GetVideos()
        {
            return (await _bll.Videos.AllAsyncWithInclude())
                .Select(PublicApi.v1.Mappers.VideoMapper.MapFromBLL).ToList();
        }

        // GET: api/Videos/5
        /// <summary>
        /// Get a Video object by id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>Video object with given id.</returns>
        /// <response code="200">Video was successfully retrieved.</response>
        /// <response code="404">Video was not found.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.DomainEntityDTOs.Video),
            StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Video>> GetVideo(int id)
        {
            var video = PublicApi.v1.Mappers.VideoMapper.MapFromBLL(await _bll.Videos.FindAsync(id));

            if (video == null)
            {
                return NotFound();
            }

            return video;
        }

        // PUT: api/Videos/5
        /// <summary>
        /// Update a Video object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <param name="video">PublicApi.v1.DTO.DomainEntityDTOs.Video type object.</param>
        /// <returns>NoContent();</returns>:TODO Add a better description!
        /// <response code="204">Video was successfully retrieved.</response>
        /// <response code="400">Video was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideo(int id, PublicApi.v1.DTO.DomainEntityDTOs.Video video)
        {
            if (id != video.Id)
            {
                return BadRequest();
            }

            _bll.Videos.Update(PublicApi.v1.Mappers.VideoMapper.MapFromExternal(video));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Videos
        /// <summary>
        /// Create and post a new Video object.
        /// </summary>
        /// <param name="video">PublicApi.v1.DTO.DomainEntityDTOs.Video type object.</param>
        /// <returns>CreatedAtAction();</returns>:TODO Add a better description!
        /// <response code="201">Video was successfully created.</response>
        /// <response code="400">Video was not created.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Video>> PostVideo(PublicApi.v1.DTO.DomainEntityDTOs.Video video)
        {
            await _bll.Videos.AddAsync(PublicApi.v1.Mappers.VideoMapper.MapFromExternal(video));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetVideo", new { id = video.Id }, video);
        }

        // DELETE: api/Videos/5
        /// <summary>
        /// Delete a Video object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>NoContent();</returns>
        /// <response code="204">Video with given id was successfully deleted.</response>
        /// <response code="404">Video with given id was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Video>> DeleteVideo(int id)
        {
            var video = await _bll.Videos.FindAsync(id);
            if (video == null)
            {
                return NotFound();
            }

            _bll.Videos.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
