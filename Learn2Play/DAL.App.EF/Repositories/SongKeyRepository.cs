using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class SongKeyRepository: BaseRepository<SongKey, AppDbContext>, ISongKeyRepository
    {
        public SongKeyRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }

        public async Task<IEnumerable<SongKey>> AllAsyncWithInclude()
        {
            return await RepositoryDbSet
                .Include(sk => sk.Note)
                .ToListAsync();
        }
        
        public override async Task<SongKey> FindAsync(params object[] id)
        {
            var songKey = await base.FindAsync(id);
            if (songKey != null)
            {
                await RepositoryDbContext.Entry(songKey)
                    .Reference(sk => sk.Note).LoadAsync();
            }
            return songKey;
        }
    }
}