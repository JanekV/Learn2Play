using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using ee.itcollege.javalg.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicApi.v1.DTO;
using PublicApi.v1.DTO.DomainEntityDTOs;
using PublicApi.v1.Mappers;

namespace WebApp.ApiControllers.v1_0
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        /// <summary>
        /// Get all Folder objects for current user.
        /// </summary>
        /// <returns>Array of all Folders.</returns>
        /// <response code="200">The array of Folders was successfully retrieved.</response>
        [ProducesResponseType(typeof(IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.Folder>),
            StatusCodes.Status200OK)]        
        [HttpGet]
        public async Task<List<Folder>> GetFolders()
        {
            return (await _bll.Folders.AllAsync(User.GetUserId()))
                .Select(PublicApi.v1.Mappers.FolderMapper.MapFromBLL).ToList();
        }

        /// <summary>
        /// Get a Folder object by id if user owns the folder.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>Folder object with given id.</returns>
        /// <response code="200">Folder was successfully retrieved.</response>
        /// <response code="404">Folder was not found.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.FolderWithSongs),
            StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.FolderWithSongs>> GetFolder(int id)
        {
            var folder = PublicApi.v1.Mappers.FolderMapper.MapFromBLL(await _bll.Folders.FindFolderWithSongsAsync(id, User.GetUserId()));

            if (folder == null)
            {
                return NotFound();
            }

            return folder;
        }

        /// <summary>
        /// Update a Folder object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <param name="folder">PublicApi.v1.DTO.DomainEntityDTOs.Folder type object.</param>
        /// <returns>NoContent();</returns>
        /// <response code="204">Folder was successfully retrieved.</response>
        /// <response code="400">Folder was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        /// <summary>
        /// Create and post a new Folder object.
        /// </summary>
        /// <param name="folder">PublicApi.v1.DTO.DomainEntityDTOs.Folder type object.</param>
        /// <returns>Created folder</returns>
        /// <response code="201">Folder was successfully created.</response>
        /// <response code="400">Folder was not created.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Folder>> PostFolder(PublicApi.v1.DTO.DomainEntityDTOs.Folder folder)
        {
            folder = PublicApi.v1.Mappers.FolderMapper.MapFromBLL(
                await _bll.Folders.AddAsync(PublicApi.v1.Mappers.FolderMapper.MapFromExternal(folder)));
            
            await _bll.SaveChangesAsync();

            folder = PublicApi.v1.Mappers.FolderMapper.MapFromBLL(
                _bll.Folders.GetUpdatesAfterUOWSaveChanges(
                PublicApi.v1.Mappers.FolderMapper.MapFromExternal(folder)));
            
            
            return CreatedAtAction(nameof(GetFolder), new
            {
                version = HttpContext.GetRequestedApiVersion().ToString(),
                id = folder.Id
            }, folder);
        }

        /// <summary>
        /// Delete a Folder object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>NoContent();</returns>
        /// <response code="204">Folder with given id was successfully deleted.</response>
        /// <response code="404">Folder with given id was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        /// <summary>
        /// Get a Folder object by id and all songs in db.
        /// </summary>
        /// <param name="folderId">Unique integer used for identification of objects.</param>
        /// <returns>Folder object with given id and all songs.</returns>
        /// <response code="200">Folder was successfully retrieved.</response>
        /// <response code="404">Folder was not found.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.AddSongToFolder),
            StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<AddSongToFolder> GetFolderWithAllSongs(int folderId)
        {
            var folder = await _bll.Folders.FindAsync(folderId);
            var fws = new AddSongToFolder()
            {
                FolderId = folderId,
                FolderName = folder.Name,
                Songs = (await _bll.Songs.AllAsync()).ConvertAll(SongMapper.MapFromBLL)
            };
            return fws;
        }

        /// <summary>
        /// Removes a song from a folder if the folder belongs to the user.
        /// </summary>
        /// <returns>NoContent();</returns>
        /// <response code="204">Folder with given id was successfully deleted.</response>
        /// <response code="404">Folder with given id was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{songId}/{folderId}")]
        public async Task<IActionResult> RemoveSong(int songId, int folderId)
        {
            var folder = await _bll.Folders.FindByFolderAndSongIdAsync(folderId, songId, User.GetUserId());
            _bll.SongChords.Remove(folder.Id);
            await _bll.SaveChangesAsync();
            return NoContent();
        }
    }
}
