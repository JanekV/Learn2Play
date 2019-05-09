using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.v1_0
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserInstrumentsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public UserInstrumentsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/UserInstruments
        /// <summary>
        /// Get all UserInstrument objects
        /// </summary>
        /// <returns>Array of all UserInstruments.</returns>
        /// <response code="200">The array of UserInstruments was successfully retrieved.</response>
        [ProducesResponseType(typeof(IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.UserInstrument>),
            StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.UserInstrument>>> GetUserInstruments()
        {
            return (await _bll.UserInstruments.AllAsyncWithInclude())
                .Select(PublicApi.v1.Mappers.UserInstrumentMapper.MapFromBLL).ToList();
        }

        // GET: api/UserInstruments/5
        /// <summary>
        /// Get a UserInstrument object by id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>UserInstrument object with given id.</returns>
        /// <response code="200">UserInstrument was successfully retrieved.</response>
        /// <response code="404">UserInstrument was not found.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.DomainEntityDTOs.UserInstrument),
            StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.UserInstrument>> GetUserInstrument(int id)
        {
            var userInstrument = PublicApi.v1.Mappers.UserInstrumentMapper.MapFromBLL(await _bll.UserInstruments.FindAsync(id));

            if (userInstrument == null)
            {
                return NotFound();
            }

            return userInstrument;
        }

        // PUT: api/UserInstruments/5
        /// <summary>
        /// Update a UserInstrument object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <param name="userInstrument">PublicApi.v1.DTO.DomainEntityDTOs.UserInstrument type object.</param>
        /// <returns>NoContent();</returns>:TODO Add a better description!
        /// <response code="204">UserInstrument was successfully retrieved.</response>
        /// <response code="400">UserInstrument was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInstrument(int id, PublicApi.v1.DTO.DomainEntityDTOs.UserInstrument userInstrument)
        {
            if (id != userInstrument.Id)
            {
                return BadRequest();
            }

            _bll.UserInstruments.Update(PublicApi.v1.Mappers.UserInstrumentMapper.MapFromExternal(userInstrument));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/UserInstruments
        /// <summary>
        /// Create and post a new UserInstrument object.
        /// </summary>
        /// <param name="userInstrument">PublicApi.v1.DTO.DomainEntityDTOs.UserInstrument type object.</param>
        /// <returns>CreatedAtAction();</returns>:TODO Add a better description!
        /// <response code="201">UserInstrument was successfully created.</response>
        /// <response code="400">UserInstrument was not created.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.UserInstrument>> PostUserInstrument(PublicApi.v1.DTO.DomainEntityDTOs.UserInstrument userInstrument)
        {
            await _bll.UserInstruments.AddAsync(PublicApi.v1.Mappers.UserInstrumentMapper.MapFromExternal(userInstrument));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetUserInstrument", new { id = userInstrument.Id }, userInstrument);
        }

        // DELETE: api/UserInstruments/5
        /// <summary>
        /// Delete a UserInstrument object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>NoContent();</returns>
        /// <response code="204">UserInstrument with given id was successfully deleted.</response>
        /// <response code="404">UserInstrument with given id was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.UserInstrument>> DeleteUserInstrument(int id)
        {
            var userInstrument = await _bll.UserInstruments.FindAsync(id);
            if (userInstrument == null)
            {
                return NotFound();
            }

            _bll.UserInstruments.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
