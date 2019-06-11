using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.v1_0
{
    [Authorize(Roles = "DbAdmin")]
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

        /// <summary>
        /// Get all Instrument objects
        /// </summary>
        /// <returns>Array of all Instruments.</returns>
        /// <response code="200">The array of Instruments was successfully retrieved.</response>
        [ProducesResponseType(typeof(IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.Instrument>),
            StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.Instrument>>> GetInstruments()
        {
            return (await _bll.Instruments.AllAsync())
                .Select(PublicApi.v1.Mappers.InstrumentMapper.MapFromBLL).ToList();
        }

        /// <summary>
        /// Get a Instrument object by id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>Instrument object with given id.</returns>
        /// <response code="200">Instrument was successfully retrieved.</response>
        /// <response code="404">Instrument was not found.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.DomainEntityDTOs.Instrument),
            StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// Update a Instrument object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <param name="instrument">PublicApi.v1.DTO.DomainEntityDTOs.Instrument type object.</param>
        /// <returns>NoContent();</returns>:TODO Add a better description!
        /// <response code="204">Instrument was successfully retrieved.</response>
        /// <response code="400">Instrument was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        /// <summary>
        /// Create and post a new Instrument object.
        /// </summary>
        /// <param name="instrument">PublicApi.v1.DTO.DomainEntityDTOs.Instrument type object.</param>
        /// <returns>CreatedAtAction();</returns>:TODO Add a better description!
        /// <response code="201">Instrument was successfully created.</response>
        /// <response code="400">Instrument was not created.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Instrument>> PostInstrument(PublicApi.v1.DTO.DomainEntityDTOs.Instrument instrument)
        {
            await _bll.Instruments.AddAsync(PublicApi.v1.Mappers.InstrumentMapper.MapFromExternal(instrument));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetInstrument", new { id = instrument.Id }, instrument);
        }

        // DELETE: api/Instruments/5
        /// <summary>
        /// Delete a Instrument object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>NoContent();</returns>
        /// <response code="204">Instrument with given id was successfully deleted.</response>
        /// <response code="404">Instrument with given id was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
