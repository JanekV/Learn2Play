using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.APIControllers.v1_0
{
    [ApiVersion("1.0")][ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
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
            return (await _bll.SongInFolders.AllAsyncWithInclude())
                .Select(PublicApi.v1.Mappers.SongInFolderMapper.MapFromBLL).ToList();
        }

        // GET: api/SongInFolders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.SongInFolder>> GetSongInFolder(int id)
        {
            var songInFolder = PublicApi.v1.Mappers.SongInFolderMapper.MapFromBLL(await _bll.SongInFolders.FindAsync(id));

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

            _bll.SongInFolders.Update(PublicApi.v1.Mappers.SongInFolderMapper.MapFromExternal(songInFolder));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/SongInFolders
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.SongInFolder>> PostSongInFolder(PublicApi.v1.DTO.DomainEntityDTOs.SongInFolder songInFolder)
        {
            await _bll.SongInFolders.AddAsync(PublicApi.v1.Mappers.SongInFolderMapper.MapFromExternal(songInFolder));
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

            _bll.SongInFolders.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
