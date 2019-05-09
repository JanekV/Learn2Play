using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.v1_0
{
    [ApiVersion("1.0")][ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SongInFolderController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public SongInFolderController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/SongInFolder
        /// <summary>
        /// Get all SongInFolder objects
        /// </summary>
        /// <returns>Array of all SongInFolders.</returns>
        /// <response code="200">The array of SongInFolders was successfully retrieved.</response>
        [ProducesResponseType(typeof(IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.SongInFolder>),
            StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.SongInFolder>>> GetSongInFolder()
        {
            return (await _bll.SongInFolders.AllAsyncWithInclude())
                .Select(PublicApi.v1.Mappers.SongInFolderMapper.MapFromBLL).ToList();
        }

        // GET: api/SongInFolder/5
        /// <summary>
        /// Get a SongInFolder object by id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>SongInFolder object with given id.</returns>
        /// <response code="200">SongInFolder was successfully retrieved.</response>
        /// <response code="404">SongInFolder was not found.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.DomainEntityDTOs.SongInFolder),
            StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        // PUT: api/SongInFolder/5
        /// <summary>
        /// Update a SongInFolder object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <param name="songInFolder">PublicApi.v1.DTO.DomainEntityDTOs.SongInFolder type object.</param>
        /// <returns>NoContent();</returns>:TODO Add a better description!
        /// <response code="204">SongInFolder was successfully retrieved.</response>
        /// <response code="400">SongInFolder was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        // POST: api/SongInFolder
        /// <summary>
        /// Create and post a new SongInFolder object.
        /// </summary>
        /// <param name="songInFolder">PublicApi.v1.DTO.DomainEntityDTOs.SongInFolder type object.</param>
        /// <returns>CreatedAtAction();</returns>:TODO Add a better description!
        /// <response code="201">SongInFolder was successfully created.</response>
        /// <response code="400">SongInFolder was not created.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.SongInFolder>> PostSongInFolder(PublicApi.v1.DTO.DomainEntityDTOs.SongInFolder songInFolder)
        {
            await _bll.SongInFolders.AddAsync(PublicApi.v1.Mappers.SongInFolderMapper.MapFromExternal(songInFolder));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetSongInFolder", new { id = songInFolder.Id }, songInFolder);
        }

        // DELETE: api/SongInFolder/5
        /// <summary>
        /// Delete a SongInFolder object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>NoContent();</returns>
        /// <response code="204">SongInFolder with given id was successfully deleted.</response>
        /// <response code="404">SongInFolder with given id was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
