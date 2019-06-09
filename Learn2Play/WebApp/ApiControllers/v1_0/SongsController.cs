using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.v1_0
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public SongsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Songs
        /// <summary>
        /// Get all Song objects
        /// </summary>
        /// <returns>Array of all Songs.</returns>
        /// <response code="200">The array of Songs was successfully retrieved.</response>
        [ProducesResponseType(typeof(IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.Song>),
            StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.DomainEntityDTOs.Song>>> GetSongs(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return (await _bll.Songs.AllAsyncWithInclude())
                    .Select(PublicApi.v1.Mappers.SongMapper.MapFromBLL).ToList();
            }
            return (await _bll.Songs.SearchSongs(search))
                .Select(PublicApi.v1.Mappers.SongMapper.MapFromBLL).ToList();
        }
        

        // GET: api/Songs/5
        /// <summary>
        /// Get a Song with everything else, videos, styles etc included.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>SongWithEverything object with given id.</returns>
        /// <response code="200">Song was successfully retrieved.</response>
        /// <response code="404">Song was not found.</response>
        [ProducesResponseType(typeof(PublicApi.v1.DTO.DomainEntityDTOs.Song),
            StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.SongWithEverything>> GetSong(int id)
        {
            var song = PublicApi.v1.Mappers.SongMapper.MapFromBLL(await _bll.Songs.GetSongWithEverythingAsync(id));

            if (song == null)
            {
                return NotFound();
            }

            return song;
        }
/*

        // PUT: api/Songs/5
        /// <summary>
        /// Update a Song object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <param name="song">PublicApi.v1.DTO.DomainEntityDTOs.Song type object.</param>
        /// <returns>NoContent();</returns>
        /// <response code="204">Song was successfully retrieved.</response>
        /// <response code="400">Song was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSong(int id, PublicApi.v1.DTO.DomainEntityDTOs.Song song)
        {
            if (id != song.Id)
            {
                return BadRequest();
            }

            _bll.Songs.Update(PublicApi.v1.Mappers.SongMapper.MapFromExternal(song));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Songs
        /// <summary>
        /// Create and post a new Song object.
        /// </summary>
        /// <param name="song">PublicApi.v1.DTO.DomainEntityDTOs.Song type object.</param>
        /// <returns>CreatedAtAction();</returns>
        /// <response code="201">Song was successfully created.</response>
        /// <response code="400">Song was not created.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Song>> PostSong(PublicApi.v1.DTO.DomainEntityDTOs.Song song)
        {
            await _bll.Songs.AddAsync(PublicApi.v1.Mappers.SongMapper.MapFromExternal(song));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetSong", new { id = song.Id }, song);
        }

        // DELETE: api/Songs/5
        /// <summary>
        /// Delete a Song object with given id.
        /// </summary>
        /// <param name="id">Unique integer used for identification of objects.</param>
        /// <returns>NoContent();</returns>
        /// <response code="204">Song with given id was successfully deleted.</response>
        /// <response code="404">Song with given id was not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.DomainEntityDTOs.Song>> DeleteSong(int id)
        {
            var song = await _bll.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            _bll.Songs.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }*/
    }
}
