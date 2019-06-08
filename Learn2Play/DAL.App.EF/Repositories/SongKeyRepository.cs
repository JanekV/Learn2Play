using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.javalg.DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using SongKey = DAL.App.DTO.DomainEntityDTOs.SongKey;

namespace DAL.App.EF.Repositories
{
    public class SongKeyRepository: BaseRepository<DAL.App.DTO.DomainEntityDTOs.SongKey, Domain.SongKey, AppDbContext>, ISongKeyRepository
    {
        public SongKeyRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new SongKeyMapper())
        {
        }

        public async Task<List<DAL.App.DTO.DomainEntityDTOs.SongKey>> AllAsyncWithInclude()
        {
            return await RepositoryDbSet
                .Include(sk => sk.Note)
                .Include(sk => sk.Description)
                .ThenInclude(s => s.Translations)
                .Select(e => SongKeyMapper.MapFromDomain(e))
                .ToListAsync();
        }
        public override async Task<DAL.App.DTO.DomainEntityDTOs.SongKey> FindAsync(params object[] id)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            var songKey = await RepositoryDbSet.FindAsync(id);
            if (songKey != null)
            {
                await RepositoryDbContext.Entry(songKey).Reference(s => s.Description).LoadAsync();
                await RepositoryDbContext.Entry(songKey.Description).Collection(m => m.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
            }
            return SongKeyMapper.MapFromDomain(songKey);
        }

        public override DAL.App.DTO.DomainEntityDTOs.SongKey Update(SongKey entity)
        {
            var entityInDb = RepositoryDbSet
                .Include(s => s.Description)
                .ThenInclude(m => m.Translations)
                .FirstOrDefault(x => x.Id == entity.Id);
            entityInDb?.Description.SetTranslation(entity.Description);
            
            return entity;
        }
        
        //Only used in WebApp.Controllers
        public async Task<SongKey> FindAsyncWithIncludeAsync(int id)
        {
            var songKey = await RepositoryDbSet
                .Include(sk => sk.Note)
                .Include(sk => sk.Description)
                .ThenInclude(s => s.Translations)
                .FirstOrDefaultAsync(sk => sk.Id == id);
            return SongKeyMapper.MapFromDomain(songKey);
        }
        
        public async Task<SongKey> FindDetachedAsync(int id)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            var songKeyEntry = RepositoryDbContext.Entry(await RepositoryDbSet.FindAsync(id));
            if (songKeyEntry == null) return null;
            await songKeyEntry.Reference(sk => sk.Description).LoadAsync();
            songKeyEntry.State = EntityState.Detached;
            var songKey = songKeyEntry.Entity;
            await RepositoryDbContext.Entry(songKey.Description).Collection(m => m.Translations)
                .Query()
                .Where(t => t.Culture == culture)
                .LoadAsync();
            return SongKeyMapper.MapFromDomain(songKey);
        }
    }
}