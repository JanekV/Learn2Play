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
using Microsoft.AspNetCore.Authorization;

namespace WebApp.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoldersController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public FoldersController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Folders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Folder>>> GetFolders()
        {
            return Ok(await _uow.Folders.AllAsync());
        }

        // GET: api/Folders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Folder>> GetFolder(int id)
        {
            var folder = await _uow.Folders.FindAsync(id);

            if (folder == null)
            {
                return NotFound();
            }

            return folder;
        }

        // PUT: api/Folders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFolder(int id, Folder folder)
        {
            if (id != folder.Id)
            {
                return BadRequest();
            }

            _uow.Folders.Update(folder);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Folders
        [HttpPost]
        public async Task<ActionResult<Folder>> PostFolder(Folder folder)
        {
            await _uow.Folders.AddAsync(folder);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetFolder", new { id = folder.Id }, folder);
        }

        // DELETE: api/Folders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Folder>> DeleteFolder(int id)
        {
            var folder = await _uow.Folders.FindAsync(id);
            if (folder == null)
            {
                return NotFound();
            }

            _uow.Folders.Remove(folder);
            await _uow.SaveChangesAsync();

            return folder;
        }
    }
}
