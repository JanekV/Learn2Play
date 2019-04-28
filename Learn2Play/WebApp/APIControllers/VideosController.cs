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
    public class VideosController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public VideosController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Videos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BLL.App.DTO.DomainEntityDTOs.Video>>> GetVideos()
        {
            return Ok(await _bll.Videos.AllAsyncWithInclude());
        }

        // GET: api/Videos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BLL.App.DTO.DomainEntityDTOs.Video>> GetVideo(int id)
        {
            var video = await _bll.Videos.FindAsync(id);

            if (video == null)
            {
                return NotFound();
            }

            return video;
        }

        // PUT: api/Videos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideo(int id, BLL.App.DTO.DomainEntityDTOs.Video video)
        {
            if (id != video.Id)
            {
                return BadRequest();
            }

            _bll.Videos.Update(video);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Videos
        [HttpPost]
        public async Task<ActionResult<BLL.App.DTO.DomainEntityDTOs.Video>> PostVideo(BLL.App.DTO.DomainEntityDTOs.Video video)
        {
            await _bll.Videos.AddAsync(video);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetVideo", new { id = video.Id }, video);
        }

        // DELETE: api/Videos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BLL.App.DTO.DomainEntityDTOs.Video>> DeleteVideo(int id)
        {
            var video = await _bll.Videos.FindAsync(id);
            if (video == null)
            {
                return NotFound();
            }

            _bll.Videos.Remove(video);
            await _bll.SaveChangesAsync();

            return video;
        }
    }
}
