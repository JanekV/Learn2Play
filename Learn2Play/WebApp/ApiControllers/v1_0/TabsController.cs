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
    public class TabsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public TabsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Tabs
        /// <summary>
        /// Get all Tab objects
        /// </summary>
        /// <returns>Array of all Tabs.</returns>
        /// <response code="200">The array of Tabs was successfully retrieved.</response>
        [ProducesResponseType(typeof(IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.Tab>),
            StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.Tab>>> GetTabs()
        {
            return (await _bll.Tabs.AllAsyncWithInclude())
                .Select(PublicApi.v1.Mappers.TabMapper.MapFromBLL).ToList();
        }

        // GET: api/Tabs/5
        /// <summary>
        /// Get a Tab object by id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>Tab object with given id.</returns>
        /// <response code="200">Tab was successfully retrieved.</response>
        /// <response code="404">Tab was not found.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.DomainEntityDTOs.Tab),
            StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Tab>> GetTab(int id)
        {
            var tab = PublicApi.v1.Mappers.TabMapper.MapFromBLL(await _bll.Tabs.FindAsync(id));

            if (tab == null)
            {
                return NotFound();
            }

            return tab;
        }

        // PUT: api/Tabs/5
        /// <summary>
        /// Update a Tab object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <param name="tab">PublicApi.v1.DTO.DomainEntityDTOs.Tab type object.</param>
        /// <returns>NoContent();</returns>:TODO Add a better description!
        /// <response code="204">Tab was successfully retrieved.</response>
        /// <response code="400">Tab was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTab(int id, PublicApi.v1.DTO.DomainEntityDTOs.Tab tab)
        {
            if (id != tab.Id)
            {
                return BadRequest();
            }

            _bll.Tabs.Update(PublicApi.v1.Mappers.TabMapper.MapFromExternal(tab));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Tabs
        /// <summary>
        /// Create and post a new Tab object.
        /// </summary>
        /// <param name="tab">PublicApi.v1.DTO.DomainEntityDTOs.Tab type object.</param>
        /// <returns>CreatedAtAction();</returns>:TODO Add a better description!
        /// <response code="201">Tab was successfully created.</response>
        /// <response code="400">Tab was not created.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Tab>> PostTab(PublicApi.v1.DTO.DomainEntityDTOs.Tab tab)
        {
            await _bll.Tabs.AddAsync(PublicApi.v1.Mappers.TabMapper.MapFromExternal(tab));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetTab", new { id = tab.Id }, tab);
        }

        // DELETE: api/Tabs/5
        /// <summary>
        /// Delete a Tab object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>NoContent();</returns>
        /// <response code="204">Tab with given id was successfully deleted.</response>
        /// <response code="404">Tab with given id was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Tab>> DeleteTab(int id)
        {
            var tab = await _bll.Tabs.FindAsync(id);
            if (tab == null)
            {
                return NotFound();
            }

            _bll.Tabs.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
