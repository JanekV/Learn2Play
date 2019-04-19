using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class SongRepository: BaseRepository<Song, AppDbContext>, ISongRepository
    {
        public SongRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }

        public async Task<IEnumerable<Song>> AllAsyncWithInclude()
        {
            return await RepositoryDbSet
                .Include(s => s.Key)
                .ToListAsync();
        }
        
        public override async Task<Song> FindAsync(params object[] id)
        {
            var song = await base.FindAsync(id);
            if (song != null)
            {
                await RepositoryDbContext.Entry(song)
                    .Reference(s => s.Key).LoadAsync();
            }
            return song;
        }
    }
}