using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class VideoRepository: BaseRepository<Video>, IVideoRepository
    {
        public VideoRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public async Task<IEnumerable<Video>> AllAsyncWithInclude()
        {
            return await RepositoryDbSet
                .Include(v => v.Song)
                .ToListAsync();
        }
        
        public override async Task<Video> FindAsync(params object[] id)
        {
            var video = await base.FindAsync(id);
            if (video != null)
            {
                await RepositoryDbContext.Entry(video)
                    .Reference(v => v.Song).LoadAsync();
            }
            return video;
        }
    }
}