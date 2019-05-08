using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;

namespace WebApp.APIControllers
{
    [Route("api/[controller]")]
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
            return Ok(await _bll.Instruments.AllAsync());
        }

        // GET: api/Instruments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Instrument>> GetInstrument(int id)
        {
            var instrument = await _bll.Instruments.FindAsync(id);

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

            _bll.Instruments.Update(instrument);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Instruments
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Instrument>> PostInstrument(PublicApi.v1.DTO.DomainEntityDTOs.Instrument instrument)
        {
            await _bll.Instruments.AddAsync(instrument);
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

            _bll.Instruments.Remove(instrument);
            await _bll.SaveChangesAsync();

            return instrument;
        }
    }
}
