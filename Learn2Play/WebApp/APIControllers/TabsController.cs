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
    public class TabsController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public TabsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Tabs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tab>>> GetTabs()
        {
            return Ok(await _uow.Tabs.AllAsyncWithInclude());
        }

        // GET: api/Tabs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tab>> GetTab(int id)
        {
            var tab = await _uow.Tabs.FindAsync(id);

            if (tab == null)
            {
                return NotFound();
            }

            return tab;
        }

        // PUT: api/Tabs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTab(int id, Tab tab)
        {
            if (id != tab.Id)
            {
                return BadRequest();
            }

            _uow.Tabs.Update(tab);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Tabs
        [HttpPost]
        public async Task<ActionResult<Tab>> PostTab(Tab tab)
        {
            await _uow.Tabs.AddAsync(tab);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetTab", new { id = tab.Id }, tab);
        }

        // DELETE: api/Tabs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tab>> DeleteTab(int id)
        {
            var tab = await _uow.Tabs.FindAsync(id);
            if (tab == null)
            {
                return NotFound();
            }

            _uow.Tabs.Remove(tab);
            await _uow.SaveChangesAsync();

            return tab;
        }
    }
}
