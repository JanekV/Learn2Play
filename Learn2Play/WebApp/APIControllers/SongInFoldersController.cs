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
    public class SongInFoldersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SongInFoldersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/SongInFolders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongInFolder>>> GetSongInFolders()
        {
            return await _context.SongInFolders.ToListAsync();
        }

        // GET: api/SongInFolders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SongInFolder>> GetSongInFolder(int id)
        {
            var songInFolder = await _context.SongInFolders.FindAsync(id);

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
            if (id != songInFolder.SongInFolderId)
            {
                return BadRequest();
            }

            _context.Entry(songInFolder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongInFolderExists(id))
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

        // POST: api/SongInFolders
        [HttpPost]
        public async Task<ActionResult<SongInFolder>> PostSongInFolder(SongInFolder songInFolder)
        {
            _context.SongInFolders.Add(songInFolder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSongInFolder", new { id = songInFolder.SongInFolderId }, songInFolder);
        }

        // DELETE: api/SongInFolders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SongInFolder>> DeleteSongInFolder(int id)
        {
            var songInFolder = await _context.SongInFolders.FindAsync(id);
            if (songInFolder == null)
            {
                return NotFound();
            }

            _context.SongInFolders.Remove(songInFolder);
            await _context.SaveChangesAsync();

            return songInFolder;
        }

        private bool SongInFolderExists(int id)
        {
            return _context.SongInFolders.Any(e => e.SongInFolderId == id);
        }
    }
}
