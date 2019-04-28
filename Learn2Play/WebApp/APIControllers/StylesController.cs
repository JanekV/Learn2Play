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
    public class StylesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public StylesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Styles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BLL.App.DTO.DomainEntityDTOs.Style>>> GetStyles()
        {
            return Ok(await _bll.Styles.AllAsync());
        }

        // GET: api/Styles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BLL.App.DTO.DomainEntityDTOs.Style>> GetStyle(int id)
        {
            var style = await _bll.Styles.FindAsync(id);

            if (style == null)
            {
                return NotFound();
            }

            return style;
        }

        // PUT: api/Styles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStyle(int id, BLL.App.DTO.DomainEntityDTOs.Style style)
        {
            if (id != style.Id)
            {
                return BadRequest();
            }

            _bll.Styles.Update(style);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Styles
        [HttpPost]
        public async Task<ActionResult<BLL.App.DTO.DomainEntityDTOs.Style>> PostStyle(BLL.App.DTO.DomainEntityDTOs.Style style)
        {
            await _bll.Styles.AddAsync(style);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetStyle", new { id = style.Id }, style);
        }

        // DELETE: api/Styles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BLL.App.DTO.DomainEntityDTOs.Style>> DeleteStyle(int id)
        {
            var style = await _bll.Styles.FindAsync(id);
            if (style == null)
            {
                return NotFound();
            }

            _bll.Styles.Remove(style);
            await _bll.SaveChangesAsync();

            return style;
        }
    }
}
