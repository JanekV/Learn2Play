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
    public class FoldersController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public FoldersController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Folders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.Folder>>> GetFolders()
        {
            return (await _bll.Folders.AllAsync())
                .Select(PublicApi.v1.Mappers.FolderMapper.MapFromBLL).ToList();
        }

        // GET: api/Folders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Folder>> GetFolder(int id)
        {
            var folder = PublicApi.v1.Mappers.FolderMapper.MapFromBLL(await _bll.Folders.FindAsync(id));

            if (folder == null)
            {
                return NotFound();
            }

            return folder;
        }

        // PUT: api/Folders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFolder(int id, PublicApi.v1.DTO.DomainEntityDTOs.Folder folder)
        {
            if (id != folder.Id)
            {
                return BadRequest();
            }

            _bll.Folders.Update(PublicApi.v1.Mappers.FolderMapper.MapFromExternal(folder));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Folders
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Folder>> PostFolder(PublicApi.v1.DTO.DomainEntityDTOs.Folder folder)
        {
            await _bll.Folders.AddAsync(PublicApi.v1.Mappers.FolderMapper.MapFromExternal(folder));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetFolder", new { id = folder.Id }, folder);
        }

        // DELETE: api/Folders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Folder>> DeleteFolder(int id)
        {
            var folder = await _bll.Folders.FindAsync(id);
            if (folder == null)
            {
                return NotFound();
            }

            _bll.Folders.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
