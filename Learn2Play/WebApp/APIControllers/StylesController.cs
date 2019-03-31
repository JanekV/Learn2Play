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
    public class StylesController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public StylesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Styles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Style>>> GetStyles()
        {
            return Ok(await _uow.Styles.AllAsync());
        }

        // GET: api/Styles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Style>> GetStyle(int id)
        {
            var style = await _uow.Styles.FindAsync(id);

            if (style == null)
            {
                return NotFound();
            }

            return style;
        }

        // PUT: api/Styles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStyle(int id, Style style)
        {
            if (id != style.Id)
            {
                return BadRequest();
            }

            _uow.Styles.Update(style);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Styles
        [HttpPost]
        public async Task<ActionResult<Style>> PostStyle(Style style)
        {
            await _uow.Styles.AddAsync(style);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetStyle", new { id = style.Id }, style);
        }

        // DELETE: api/Styles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Style>> DeleteStyle(int id)
        {
            var style = await _uow.Styles.FindAsync(id);
            if (style == null)
            {
                return NotFound();
            }

            _uow.Styles.Remove(style);
            await _uow.SaveChangesAsync();

            return style;
        }
    }
}
