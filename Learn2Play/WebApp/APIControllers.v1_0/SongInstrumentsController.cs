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
    public class SongInstrumentsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public SongInstrumentsController(IAppBLL bll)
        {
            _bll = bll;
        }


        // GET: api/SongInstruments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.SongInstrument>>> GetSongInstruments()
        {
            return (await _bll.SongInstruments.AllAsyncWithInclude())
                .Select(PublicApi.v1.Mappers.SongInstrumentMapper.MapFromBLL).ToList();
        }

        // GET: api/SongInstruments/5
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
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.SongInstrument>> PostSongInstrument(PublicApi.v1.DTO.DomainEntityDTOs.SongInstrument songInstrument)
        {
            await _bll.SongInstruments.AddAsync(PublicApi.v1.Mappers.SongInstrumentMapper.MapFromExternal(songInstrument));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetSongInstrument", new { id = songInstrument.Id }, songInstrument);
        }

        // DELETE: api/SongInstruments/5
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
