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
    public class SongInFoldersController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public SongInFoldersController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/SongInFolders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.SongInFolder>>> GetSongInFolders()
        {
            return Ok(await _bll.SongInFolders.AllAsyncWithInclude());
        }

        // GET: api/SongInFolders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.SongInFolder>> GetSongInFolder(int id)
        {
            var songInFolder = await _bll.SongInFolders.FindAsync(id);

            if (songInFolder == null)
            {
                return NotFound();
            }

            return songInFolder;
        }

        // PUT: api/SongInFolders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongInFolder(int id, PublicApi.v1.DTO.DomainEntityDTOs.SongInFolder songInFolder)
        {
            if (id != songInFolder.Id)
            {
                return BadRequest();
            }

            _bll.SongInFolders.Update(songInFolder);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/SongInFolders
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.SongInFolder>> PostSongInFolder(PublicApi.v1.DTO.DomainEntityDTOs.SongInFolder songInFolder)
        {
            await _bll.SongInFolders.AddAsync(songInFolder);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetSongInFolder", new { id = songInFolder.Id }, songInFolder);
        }

        // DELETE: api/SongInFolders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.SongInFolder>> DeleteSongInFolder(int id)
        {
            var songInFolder = await _bll.SongInFolders.FindAsync(id);
            if (songInFolder == null)
            {
                return NotFound();
            }

            _bll.SongInFolders.Remove(songInFolder);
            await _bll.SaveChangesAsync();

            return songInFolder;
        }
    }
}
