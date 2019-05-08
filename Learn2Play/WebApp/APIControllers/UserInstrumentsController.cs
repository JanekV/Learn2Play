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
            return Ok(await _bll.UserInstruments.AllAsyncWithInclude());
        }

        // GET: api/UserInstruments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.UserInstrument>> GetUserInstrument(int id)
        {
            var userInstrument = await _bll.UserInstruments.FindAsync(id);

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

            _bll.UserInstruments.Update(userInstrument);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/UserInstruments
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.UserInstrument>> PostUserInstrument(PublicApi.v1.DTO.DomainEntityDTOs.UserInstrument userInstrument)
        {
            await _bll.UserInstruments.AddAsync(userInstrument);
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

            _bll.UserInstruments.Remove(userInstrument);
            await _bll.SaveChangesAsync();

            return userInstrument;
        }
    }
}
