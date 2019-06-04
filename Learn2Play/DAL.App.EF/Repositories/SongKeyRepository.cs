using System.Collections.Generic;
using System.Linq;
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
                .Select(e => SongKeyMapper.MapFromDomain(e))
                .ToListAsync();
        }
        
        public async Task<SongKey> FindAsyncWithIncludeAsync(int id)
        {
            var songKey = await RepositoryDbSet
                .Include(sk => sk.Note)
                .FirstOrDefaultAsync(sk => sk.Id == id);
            
            
            return SongKeyMapper.MapFromDomain(songKey);
        }
    }
}