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
using Microsoft.AspNetCore.Authorization;

namespace WebApp.APIControllers
{
    [Route("api/[controller]")]
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
            return (await _bll.Folders.AllAsync());
        }

        // GET: api/Folders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Folder>> GetFolder(int id)
        {
            var folder = await _bll.Folders.FindAsync(id);

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

            _bll.Folders.Update(folder);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Folders
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Folder>> PostFolder(PublicApi.v1.DTO.DomainEntityDTOs.Folder folder)
        {
            await _bll.Folders.AddAsync(folder);
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

            _bll.Folders.Remove(folder);
            await _bll.SaveChangesAsync();

            return folder;
        }
    }
}
