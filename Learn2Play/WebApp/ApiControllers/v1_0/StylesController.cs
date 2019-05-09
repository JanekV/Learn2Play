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
    public class StylesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public StylesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Styles
        /// <summary>
        /// Get all Style objects
        /// </summary>
        /// <returns>Array of all Styles.</returns>
        /// <response code="200">The array of Styles was successfully retrieved.</response>
        [ProducesResponseType(typeof(IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.Style>),
            StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.Style>>> GetStyles()
        {
            return (await _bll.Styles.AllAsync())
                .Select(PublicApi.v1.Mappers.StyleMapper.MapFromBLL).ToList();
        }

        // GET: api/Styles/5
        /// <summary>
        /// Get a Style object by id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>Style object with given id.</returns>
        /// <response code="200">Style was successfully retrieved.</response>
        /// <response code="404">Style was not found.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.DomainEntityDTOs.Style),
            StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        /// <summary>
        /// Update a Style object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <param name="style">PublicApi.v1.DTO.DomainEntityDTOs.Style type object.</param>
        /// <returns>NoContent();</returns>:TODO Add a better description!
        /// <response code="204">Style was successfully retrieved.</response>
        /// <response code="400">Style was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        /// <summary>
        /// Create and post a new Style object.
        /// </summary>
        /// <param name="style">PublicApi.v1.DTO.DomainEntityDTOs.Style type object.</param>
        /// <returns>CreatedAtAction();</returns>:TODO Add a better description!
        /// <response code="201">Style was successfully created.</response>
        /// <response code="400">Style was not created.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Style>> PostStyle(PublicApi.v1.DTO.DomainEntityDTOs.Style style)
        {
            await _bll.Styles.AddAsync(PublicApi.v1.Mappers.StyleMapper.MapFromExternal(style));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetStyle", new { id = style.Id }, style);
        }

        // DELETE: api/Styles/5
        /// <summary>
        /// Delete a Style object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>NoContent();</returns>
        /// <response code="204">Style with given id was successfully deleted.</response>
        /// <response code="404">Style with given id was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
