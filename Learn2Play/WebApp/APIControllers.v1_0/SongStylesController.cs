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
    public class SongStylesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public SongStylesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/SongStyles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.SongStyle>>> GetSongStyles()
        {
            return (await _bll.SongStyles.AllAsyncWithInclude())
                .Select(PublicApi.v1.Mappers.SongStyleMapper.MapFromBLL).ToList();
        }

        // GET: api/SongStyles/5
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
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.SongStyle>> PostSongStyle(PublicApi.v1.DTO.DomainEntityDTOs.SongStyle songStyle)
        {
            await _bll.SongStyles.AddAsync(PublicApi.v1.Mappers.SongStyleMapper.MapFromExternal(songStyle));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetSongStyle", new { id = songStyle.Id }, songStyle);
        }

        // DELETE: api/SongStyles/5
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
