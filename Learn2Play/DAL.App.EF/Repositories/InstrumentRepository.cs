using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.javalg.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Instrument = DAL.App.DTO.DomainEntityDTOs.Instrument;

namespace DAL.App.EF.Repositories
{
    public class InstrumentRepository: BaseRepository<DAL.App.DTO.DomainEntityDTOs.Instrument, Domain.Instrument, AppDbContext>, IInstrumentRepository
    {
        public InstrumentRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new InstrumentMapper())
        {
        }
        
        public async Task<Instrument> FindDetachedAsync(int id)
        {
            var instrumentEntry = RepositoryDbContext.Entry(await RepositoryDbSet.FindAsync(id));
            if (instrumentEntry == null) return null;
            instrumentEntry.State = EntityState.Detached;
            var instrument = instrumentEntry.Entity;
            return InstrumentMapper.MapFromDomain(instrument);
        }
    }
}