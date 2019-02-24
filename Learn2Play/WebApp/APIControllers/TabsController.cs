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
    public class TabsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TabsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Tabs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tab>>> GetTabs()
        {
            return await _context.Tabs.ToListAsync();
        }

        // GET: api/Tabs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tab>> GetTab(int id)
        {
            var tab = await _context.Tabs.FindAsync(id);

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
            if (id != tab.TabId)
            {
                return BadRequest();
            }

            _context.Entry(tab).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TabExists(id))
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

        // POST: api/Tabs
        [HttpPost]
        public async Task<ActionResult<Tab>> PostTab(Tab tab)
        {
            _context.Tabs.Add(tab);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTab", new { id = tab.TabId }, tab);
        }

        // DELETE: api/Tabs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tab>> DeleteTab(int id)
        {
            var tab = await _context.Tabs.FindAsync(id);
            if (tab == null)
            {
                return NotFound();
            }

            _context.Tabs.Remove(tab);
            await _context.SaveChangesAsync();

            return tab;
        }

        private bool TabExists(int id)
        {
            return _context.Tabs.Any(e => e.TabId == id);
        }
    }
}
