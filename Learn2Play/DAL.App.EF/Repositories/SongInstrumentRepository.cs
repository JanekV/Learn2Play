using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.javalg.DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class SongInstrumentRepository: BaseRepository<DAL.App.DTO.DomainEntityDTOs.SongInstrument, Domain.SongInstrument, AppDbContext>, ISongInstrumentRepository
    {
        public SongInstrumentRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new SongInstrumentMapper())
        {
        }

        public async Task<List<DAL.App.DTO.DomainEntityDTOs.SongInstrument>> AllAsyncWithInclude()
        {
            return await RepositoryDbSet
                .Include(si => si.Song)
                .Include(si => si.Instrument)
                .Select(e => SongInstrumentMapper.MapFromDomain(e))
                .ToListAsync();
        }
        
        public async Task<DAL.App.DTO.DomainEntityDTOs.SongInstrument> FindAsync(int id)
        {
            var songInstrument = await RepositoryDbSet
                .Include(si => si.Song)
                .Include(si => si.Instrument)
                .FirstOrDefaultAsync(si => si.Id == id);
            
            
            return SongInstrumentMapper.MapFromDomain(songInstrument);
        }

        public async Task<DAL.App.DTO.DomainEntityDTOs.SongInstrument> FindByInstrumentAndSongIdAsync(int instrumentId, int songId)
        {
            var songInstrument = await RepositoryDbSet
                .Where(si => si.InstrumentId == instrumentId && si.SongId == songId)
                .FirstOrDefaultAsync();
            return SongInstrumentMapper.MapFromDomain(songInstrument);
        }
    }
}