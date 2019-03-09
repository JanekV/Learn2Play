using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class SongInstrumentRepository: BaseRepository<SongInstrument>, ISongInstrumentRepository
    {
        public SongInstrumentRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public async Task<IEnumerable<SongInstrument>> AllAsyncWithInclude()
        {
            return await RepositoryDbSet
                .Include(si => si.Song)
                .Include(si => si.Instrument)
                .ToListAsync();
        }
        
        public override async Task<SongInstrument> FindAsync(params object[] id)
        {
            var songInstrument = await base.FindAsync(id);
            if (songInstrument != null)
            {
                await RepositoryDbContext.Entry(songInstrument)
                    .Reference(si => si.Song).LoadAsync();
                await RepositoryDbContext.Entry(songInstrument)
                    .Reference(si => si.Instrument).LoadAsync();
            }
            return songInstrument;
        }
    }
}