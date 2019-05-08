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
    public class SongKeysController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public SongKeysController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/SongKeys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.SongKey>>> GetSongKeys()
        {
            return (await _bll.SongKeys.AllAsyncWithInclude())
                .Select(PublicApi.v1.Mappers.SongKeyMapper.MapFromBLL).ToList();
        }

        // GET: api/SongKeys/5
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
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.SongKey>> PostSongKey(PublicApi.v1.DTO.DomainEntityDTOs.SongKey songKey)
        {
            await _bll.SongKeys.AddAsync(PublicApi.v1.Mappers.SongKeyMapper.MapFromExternal(songKey));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetSongKey", new { id = songKey.Id }, songKey);
        }

        // DELETE: api/SongKeys/5
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
