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
    public class VideosController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public VideosController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Videos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.Video>>> GetVideos()
        {
            return (await _bll.Videos.AllAsyncWithInclude())
                .Select(PublicApi.v1.Mappers.VideoMapper.MapFromBLL).ToList();
        }

        // GET: api/Videos/5
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
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Video>> PostVideo(PublicApi.v1.DTO.DomainEntityDTOs.Video video)
        {
            await _bll.Videos.AddAsync(PublicApi.v1.Mappers.VideoMapper.MapFromExternal(video));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetVideo", new { id = video.Id }, video);
        }

        // DELETE: api/Videos/5
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
