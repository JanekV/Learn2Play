using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

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
                .Select(e => SongKeyMapper.MapFromDomain(e))
                .ToListAsync();
        }
        
        public async Task<DAL.App.DTO.DomainEntityDTOs.SongKey> FindAsync(int id)
        {
/*
            var songKey = await base.FindAsync(id);
            if (songKey != null)
            {
                await RepositoryDbContext.Entry(songKey)
                    .Reference(sk => sk.Note).LoadAsync();
            }
            return songKey;
            */

            var songKey = await RepositoryDbSet
                .Include(sk => sk.Note)
                .FirstOrDefaultAsync(sk => sk.Id == id);
            
            
            return SongKeyMapper.MapFromDomain(songKey);
        }
    }
}