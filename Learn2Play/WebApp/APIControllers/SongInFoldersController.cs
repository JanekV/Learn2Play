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
    public class SongInFoldersController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public SongInFoldersController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/SongInFolders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongInFolder>>> GetSongInFolders()
        {
            return Ok(await _uow.SongInFolders.AllAsyncWithInclude());
        }

        // GET: api/SongInFolders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SongInFolder>> GetSongInFolder(int id)
        {
            var songInFolder = await _uow.SongInFolders.FindAsync(id);

            if (songInFolder == null)
            {
                return NotFound();
            }

            return songInFolder;
        }

        // PUT: api/SongInFolders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongInFolder(int id, SongInFolder songInFolder)
        {
            if (id != songInFolder.Id)
            {
                return BadRequest();
            }

            _uow.SongInFolders.Update(songInFolder);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/SongInFolders
        [HttpPost]
        public async Task<ActionResult<SongInFolder>> PostSongInFolder(SongInFolder songInFolder)
        {
            await _uow.SongInFolders.AddAsync(songInFolder);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetSongInFolder", new { id = songInFolder.Id }, songInFolder);
        }

        // DELETE: api/SongInFolders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SongInFolder>> DeleteSongInFolder(int id)
        {
            var songInFolder = await _uow.SongInFolders.FindAsync(id);
            if (songInFolder == null)
            {
                return NotFound();
            }

            _uow.SongInFolders.Remove(songInFolder);
            await _uow.SaveChangesAsync();

            return songInFolder;
        }
    }
}
