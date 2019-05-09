using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.APIControllers.v1_0
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ChordsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public ChordsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Chords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.Chord>>> GetChords()
        {
            return (await _bll.Chords.AllAsync())
                .Select(PublicApi.v1.Mappers.ChordMapper.MapFromBLL).ToList();
        }

        // GET: api/Chords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Chord>> GetChord(int id)
        {
            var chord = PublicApi.v1.Mappers.ChordMapper.MapFromBLL(await _bll.Chords.FindAsync(id));

            if (chord == null)
            {
                return NotFound();
            }

            return chord;
        }

        // PUT: api/Chords/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChord(int id, PublicApi.v1.DTO.DomainEntityDTOs.Chord chord)
        {
            if (id != chord.Id)
            {
                return BadRequest();
            }

            _bll.Chords.Update(PublicApi.v1.Mappers.ChordMapper.MapFromExternal(chord));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Chords
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Chord>> PostChord(PublicApi.v1.DTO.DomainEntityDTOs.Chord chord)
        {
            await _bll.Chords.AddAsync(PublicApi.v1.Mappers.ChordMapper.MapFromExternal(chord));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetChord", new { id = chord.Id }, chord);
        }

        // DELETE: api/Chords/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Chord>> DeleteChord(int id)
        {
            var chord = await _bll.Chords.FindAsync(id);
            if (chord == null)
            {
                return NotFound();
            }

            _bll.Chords.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
