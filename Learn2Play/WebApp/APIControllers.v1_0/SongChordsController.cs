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
    public class SongChordsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public SongChordsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/SongChords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.SongChord>>> GetSongChords()
        {
            return (await _bll.SongChords.AllAsyncWithInclude())
                .Select(PublicApi.v1.Mappers.SongChordMapper.MapFromBLL).ToList();
        }

        // GET: api/SongChords/5
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
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.SongChord>> PostSongChord(PublicApi.v1.DTO.DomainEntityDTOs.SongChord songChord)
        {
            await _bll.SongChords.AddAsync(PublicApi.v1.Mappers.SongChordMapper.MapFromExternal(songChord));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetSongChord", new { id = songChord.Id }, songChord);
        }

        // DELETE: api/SongChords/5
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
