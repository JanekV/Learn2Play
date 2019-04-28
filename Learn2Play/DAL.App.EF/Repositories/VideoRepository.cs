using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

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
                .Select(e => VideoMapper.MapFromDomain(e))
                .ToListAsync();
        }
        
        public async Task<DAL.App.DTO.DomainEntityDTOs.Video> FindAsync(int id)
        {
            /*var video = await base.FindAsync(id);
            if (video != null)
            {
                await RepositoryDbContext.Entry(video)
                    .Reference(v => v.Song).LoadAsync();
            }
            return video;
            */

            var video = await RepositoryDbSet
                .Include(v => v.Song)
                .FirstOrDefaultAsync(v => v.Id == id);
            
            
            return VideoMapper.MapFromDomain(video);
        }
    }
}