using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class SongStyleRepository: BaseRepository<SongStyle, AppDbContext>, ISongStyleRepository
    {
        public SongStyleRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }

        public async Task<IEnumerable<SongStyle>> AllAsyncWithInclude()
        {
            return await RepositoryDbSet
                .Include(ss => ss.Song)
                .Include(ss => ss.Style)
                .ToListAsync();
        }
        
        public override async Task<SongStyle> FindAsync(params object[] id)
        {
            var songStyle = await base.FindAsync(id);
            if (songStyle != null)
            {
                await RepositoryDbContext.Entry(songStyle)
                    .Reference(ss => ss.Song).LoadAsync();
                await RepositoryDbContext.Entry(songStyle)
                    .Reference(ss => ss.Style).LoadAsync();
            }
            return songStyle;
        }
    }
}