using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        public override async Task<List<DAL.App.DTO.DomainEntityDTOs.Instrument>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(instrument => instrument.Name)
                .ThenInclude(s => s.Translations)
                .Include(instrument => instrument.Description)
                .ThenInclude(s => s.Translations)
                .Select(e => InstrumentMapper.MapFromDomain(e))
                .ToListAsync();
        }

        public override async Task<DAL.App.DTO.DomainEntityDTOs.Instrument> FindAsync(params object[] id)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            var instrument = await RepositoryDbSet.FindAsync(id);
            if (instrument != null)
            {
                await RepositoryDbContext.Entry(instrument).Reference(s => s.Name).LoadAsync();
                await RepositoryDbContext.Entry(instrument.Name).Collection(m => m.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
                await RepositoryDbContext.Entry(instrument).Reference(s => s.Description).LoadAsync();
                await RepositoryDbContext.Entry(instrument.Description).Collection(m => m.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
            }
            return InstrumentMapper.MapFromDomain(instrument);
        }

        public override DAL.App.DTO.DomainEntityDTOs.Instrument Update(Instrument entity)
        {
            var entityInDb = RepositoryDbSet
                .Include(s => s.Name)
                .ThenInclude(m => m.Translations)
                .Include(s => s.Description)
                .ThenInclude(m => m.Translations)
                .FirstOrDefault(x => x.Id == entity.Id);

            entityInDb?.Name.SetTranslation(entity.Name);
            entityInDb?.Description.SetTranslation(entity.Description);
            return entity;
        }
        public async Task<Instrument> FindDetachedAsync(int id)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            var instrumentEntry = RepositoryDbContext.Entry(await RepositoryDbSet.FindAsync(id));
            if (instrumentEntry == null) return null;
            await instrumentEntry.Reference(s => s.Name).LoadAsync();
            await instrumentEntry.Reference(s => s.Description).LoadAsync();
            instrumentEntry.State = EntityState.Detached;
            var instrument = instrumentEntry.Entity;
            await RepositoryDbContext.Entry(instrument.Name).Collection(m => m.Translations)
                .Query()
                .Where(t => t.Culture == culture)
                .LoadAsync();
            await RepositoryDbContext.Entry(instrument.Description).Collection(m => m.Translations)
                .Query()
                .Where(t => t.Culture == culture)
                .LoadAsync();
            return InstrumentMapper.MapFromDomain(instrument);
        }

        public async Task<List<Instrument>> GetInstrumentsForIds(List<int> ids)
        {
            var res = new List<Instrument>();
            foreach (var id in ids)
            {
                var instrument = await FindAsync(id);
                res.Add(instrument);
            }
            return res;
        }
    }
}