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
    public class StylesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public StylesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Styles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.Style>>> GetStyles()
        {
            return (await _bll.Styles.AllAsync())
                .Select(PublicApi.v1.Mappers.StyleMapper.MapFromBLL).ToList();
        }

        // GET: api/Styles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Style>> GetStyle(int id)
        {
            var style = PublicApi.v1.Mappers.StyleMapper.MapFromBLL(await _bll.Styles.FindAsync(id));

            if (style == null)
            {
                return NotFound();
            }

            return style;
        }

        // PUT: api/Styles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStyle(int id, PublicApi.v1.DTO.DomainEntityDTOs.Style style)
        {
            if (id != style.Id)
            {
                return BadRequest();
            }

            _bll.Styles.Update(PublicApi.v1.Mappers.StyleMapper.MapFromExternal(style));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Styles
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Style>> PostStyle(PublicApi.v1.DTO.DomainEntityDTOs.Style style)
        {
            await _bll.Styles.AddAsync(PublicApi.v1.Mappers.StyleMapper.MapFromExternal(style));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetStyle", new { id = style.Id }, style);
        }

        // DELETE: api/Styles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Style>> DeleteStyle(int id)
        {
            var style = await _bll.Styles.FindAsync(id);
            if (style == null)
            {
                return NotFound();
            }

            _bll.Styles.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
