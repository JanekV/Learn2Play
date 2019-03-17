using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentsController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public InstrumentsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Instruments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instrument>>> GetInstruments()
        {
            return Ok(await _uow.Instruments.AllAsync());
        }

        // GET: api/Instruments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Instrument>> GetInstrument(int id)
        {
            var instrument = await _uow.Instruments.FindAsync(id);

            if (instrument == null)
            {
                return NotFound();
            }

            return instrument;
        }

        // PUT: api/Instruments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstrument(int id, Instrument instrument)
        {
            if (id != instrument.Id)
            {
                return BadRequest();
            }

            _uow.Instruments.Update(instrument);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Instruments
        [HttpPost]
        public async Task<ActionResult<Instrument>> PostInstrument(Instrument instrument)
        {
            await _uow.Instruments.AddAsync(instrument);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetInstrument", new { id = instrument.Id }, instrument);
        }

        // DELETE: api/Instruments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Instrument>> DeleteInstrument(int id)
        {
            var instrument = await _uow.Instruments.FindAsync(id);
            if (instrument == null)
            {
                return NotFound();
            }

            _uow.Instruments.Remove(instrument);
            await _uow.SaveChangesAsync();

            return instrument;
        }
    }
}
