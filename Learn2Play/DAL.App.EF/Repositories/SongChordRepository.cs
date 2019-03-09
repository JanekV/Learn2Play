using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class SongChordRepository: BaseRepository<SongChord>, ISongChordRepository
    {
        public SongChordRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public async Task<IEnumerable<SongChord>> AllAsyncWithInclude()
        {
            return await RepositoryDbSet
                .Include(sc => sc.Chord)
                .Include(sc => sc.Song)
                .ToListAsync();
        }

        public override async Task<SongChord> FindAsync(params object[] id)
        {
            var songChord = await base.FindAsync(id);
            if (songChord != null)
            {
                await RepositoryDbContext.Entry(songChord)
                    .Reference(sc => sc.Song).LoadAsync();
                await RepositoryDbContext.Entry(songChord)
                    .Reference(sc => sc.Chord).LoadAsync();
            }
            
            
            return songChord;
        }
    }
}