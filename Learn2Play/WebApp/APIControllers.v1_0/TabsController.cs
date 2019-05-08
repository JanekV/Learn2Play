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
    public class TabsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public TabsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Tabs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.Tab>>> GetTabs()
        {
            return (await _bll.Tabs.AllAsyncWithInclude())
                .Select(PublicApi.v1.Mappers.TabMapper.MapFromBLL).ToList();
        }

        // GET: api/Tabs/5
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
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Tab>> PostTab(PublicApi.v1.DTO.DomainEntityDTOs.Tab tab)
        {
            await _bll.Tabs.AddAsync(PublicApi.v1.Mappers.TabMapper.MapFromExternal(tab));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetTab", new { id = tab.Id }, tab);
        }

        // DELETE: api/Tabs/5
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
