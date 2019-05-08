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
    public class SongsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public SongsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Songs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.Song>>> GetSongs()
        {
            return (await _bll.Songs.AllAsyncWithInclude())
                .Select(PublicApi.v1.Mappers.SongMapper.MapFromBLL).ToList();
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Song>> GetSong(int id)
        {
            var song = PublicApi.v1.Mappers.SongMapper.MapFromBLL(await _bll.Songs.FindAsync(id));

            if (song == null)
            {
                return NotFound();
            }

            return song;
        }

        // PUT: api/Songs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSong(int id, PublicApi.v1.DTO.DomainEntityDTOs.Song song)
        {
            if (id != song.Id)
            {
                return BadRequest();
            }

            _bll.Songs.Update(PublicApi.v1.Mappers.SongMapper.MapFromExternal(song));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Songs
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Song>> PostSong(PublicApi.v1.DTO.DomainEntityDTOs.Song song)
        {
            await _bll.Songs.AddAsync(PublicApi.v1.Mappers.SongMapper.MapFromExternal(song));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetSong", new { id = song.Id }, song);
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Song>> DeleteSong(int id)
        {
            var song = await _bll.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            _bll.Songs.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
