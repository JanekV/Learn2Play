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
    public class SongRepository: BaseRepository<DAL.App.DTO.DomainEntityDTOs.Song, Domain.Song, AppDbContext>, ISongRepository
    {
        public SongRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new SongMapper())
        {
        }

        public async Task<List<DAL.App.DTO.DomainEntityDTOs.Song>> AllAsyncWithInclude()
        {
            return await RepositoryDbSet
                .Include(s => s.SongKey)
                .Select(e => SongMapper.MapFromDomain(e))
                .ToListAsync();
        }
        
        public async Task<DAL.App.DTO.DomainEntityDTOs.Song> FindAsync(int id)
        {
/*
            var song = await base.FindAsync(id);
            if (song != null)
            {
                await RepositoryDbContext.Entry(song)
                    .Reference(s => s.SongKey).LoadAsync();
            }
            return song;
            */

            var song = await RepositoryDbSet
                .Include(s => s.SongKey)
                .FirstOrDefaultAsync(s => s.Id == id);
            
            
            return SongMapper.MapFromDomain(song);
        }
    }
}