using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IAppUnitOfWork _uow;

        public UserInstrumentsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/UserInstruments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInstrument>>> GetUserInstruments()
        {
            return Ok(await _uow.UserInstruments.AllAsyncWithInclude());
        }

        // GET: api/UserInstruments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInstrument>> GetUserInstrument(int id)
        {
            var userInstrument = await _uow.UserInstruments.FindAsync(id);

            if (userInstrument == null)
            {
                return NotFound();
            }

            return userInstrument;
        }

        // PUT: api/UserInstruments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInstrument(int id, UserInstrument userInstrument)
        {
            if (id != userInstrument.Id)
            {
                return BadRequest();
            }

            _uow.UserInstruments.Update(userInstrument);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/UserInstruments
        [HttpPost]
        public async Task<ActionResult<UserInstrument>> PostUserInstrument(UserInstrument userInstrument)
        {
            await _uow.UserInstruments.AddAsync(userInstrument);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetUserInstrument", new { id = userInstrument.Id }, userInstrument);
        }

        // DELETE: api/UserInstruments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserInstrument>> DeleteUserInstrument(int id)
        {
            var userInstrument = await _uow.UserInstruments.FindAsync(id);
            if (userInstrument == null)
            {
                return NotFound();
            }

            _uow.UserInstruments.Remove(userInstrument);
            await _uow.SaveChangesAsync();

            return userInstrument;
        }
    }
}
