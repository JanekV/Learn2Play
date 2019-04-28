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
    public class SongChordRepository: BaseRepository<DAL.App.DTO.DomainEntityDTOs.SongChord, Domain.SongChord, AppDbContext>, ISongChordRepository
    {
        public SongChordRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new SongChordMapper())
        {
        }

        public async Task<List<DAL.App.DTO.DomainEntityDTOs.SongChord>> AllAsyncWithInclude()
        {
            return await RepositoryDbSet
                .Include(sc => sc.Chord)
                .Include(sc => sc.Song)
                .Select(e => SongChordMapper.MapFromDomain(e))
                .ToListAsync();
        }

        public async Task<DAL.App.DTO.DomainEntityDTOs.SongChord> FindAsync(int id)
        {
            var songChord = await RepositoryDbSet
                .Include(sc => sc.Chord)
                .Include(sc => sc.Song)
                .FirstOrDefaultAsync(sc => sc.Id == id);
            
            
            return SongChordMapper.MapFromDomain(songChord);

        }
    }
}