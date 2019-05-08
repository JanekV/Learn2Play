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
    public class UserInstrumentsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public UserInstrumentsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/UserInstruments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.UserInstrument>>> GetUserInstruments()
        {
            return (await _bll.UserInstruments.AllAsyncWithInclude())
                .Select(PublicApi.v1.Mappers.UserInstrumentMapper.MapFromBLL).ToList();
        }

        // GET: api/UserInstruments/5
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
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.UserInstrument>> PostUserInstrument(PublicApi.v1.DTO.DomainEntityDTOs.UserInstrument userInstrument)
        {
            await _bll.UserInstruments.AddAsync(PublicApi.v1.Mappers.UserInstrumentMapper.MapFromExternal(userInstrument));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetUserInstrument", new { id = userInstrument.Id }, userInstrument);
        }

        // DELETE: api/UserInstruments/5
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
