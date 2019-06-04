using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.javalg.DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Video = DAL.App.DTO.DomainEntityDTOs.Video;

namespace DAL.App.EF.Repositories
{
    public class VideoRepository: BaseRepository<DAL.App.DTO.DomainEntityDTOs.Video, Domain.Video, AppDbContext>, IVideoRepository
    {
        public VideoRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new VideoMapper())
        {
        }

        public async Task<List<DAL.App.DTO.DomainEntityDTOs.Video>> AllAsyncWithInclude()
        {
            return await RepositoryDbSet
                .Include(v => v.Song)
                .Include(v => v.Tabs.Select(TabMapper.MapFromDomain).ToList())
                .Select(e => VideoMapper.MapFromDomain(e))
                .ToListAsync();
        }

        public async Task<Video> FindAsyncWithIncludeAsync(int id)
        {
            var video = await RepositoryDbSet
                .Include(v => v.Song)
                .Include(v => v.Tabs.Select(TabMapper.MapFromDomain).ToList())
                .FirstOrDefaultAsync(v => v.Id == id);
            return VideoMapper.MapFromDomain(video);
        }
        
    }
}