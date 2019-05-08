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
    public class InstrumentsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public InstrumentsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Instruments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.Instrument>>> GetInstruments()
        {
            return (await _bll.Instruments.AllAsync())
                .Select(PublicApi.v1.Mappers.InstrumentMapper.MapFromBLL).ToList();
        }

        // GET: api/Instruments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Instrument>> GetInstrument(int id)
        {
            var instrument = PublicApi.v1.Mappers.InstrumentMapper.MapFromBLL(await _bll.Instruments.FindAsync(id));

            if (instrument == null)
            {
                return NotFound();
            }

            return instrument;
        }

        // PUT: api/Instruments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstrument(int id, PublicApi.v1.DTO.DomainEntityDTOs.Instrument instrument)
        {
            if (id != instrument.Id)
            {
                return BadRequest();
            }

            _bll.Instruments.Update(PublicApi.v1.Mappers.InstrumentMapper.MapFromExternal(instrument));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Instruments
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Instrument>> PostInstrument(PublicApi.v1.DTO.DomainEntityDTOs.Instrument instrument)
        {
            await _bll.Instruments.AddAsync(PublicApi.v1.Mappers.InstrumentMapper.MapFromExternal(instrument));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetInstrument", new { id = instrument.Id }, instrument);
        }

        // DELETE: api/Instruments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Instrument>> DeleteInstrument(int id)
        {
            var instrument = await _bll.Instruments.FindAsync(id);
            if (instrument == null)
            {
                return NotFound();
            }

            _bll.Instruments.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
