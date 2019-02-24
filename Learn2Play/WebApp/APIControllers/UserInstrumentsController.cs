using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInstrumentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserInstrumentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UserInstruments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInstrument>>> GetUserInstruments()
        {
            return await _context.UserInstruments.ToListAsync();
        }

        // GET: api/UserInstruments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInstrument>> GetUserInstrument(int id)
        {
            var userInstrument = await _context.UserInstruments.FindAsync(id);

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
            if (id != userInstrument.UserInstrumentId)
            {
                return BadRequest();
            }

            _context.Entry(userInstrument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInstrumentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserInstruments
        [HttpPost]
        public async Task<ActionResult<UserInstrument>> PostUserInstrument(UserInstrument userInstrument)
        {
            _context.UserInstruments.Add(userInstrument);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserInstrument", new { id = userInstrument.UserInstrumentId }, userInstrument);
        }

        // DELETE: api/UserInstruments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserInstrument>> DeleteUserInstrument(int id)
        {
            var userInstrument = await _context.UserInstruments.FindAsync(id);
            if (userInstrument == null)
            {
                return NotFound();
            }

            _context.UserInstruments.Remove(userInstrument);
            await _context.SaveChangesAsync();

            return userInstrument;
        }

        private bool UserInstrumentExists(int id)
        {
            return _context.UserInstruments.Any(e => e.UserInstrumentId == id);
        }
    }
}
