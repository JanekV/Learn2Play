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
    public class SongStyleRepository: BaseRepository<DAL.App.DTO.DomainEntityDTOs.SongStyle, Domain.SongStyle, AppDbContext>, ISongStyleRepository
    {
        public SongStyleRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new SongStyleMapper())
        {
        }

        public async Task<List<DAL.App.DTO.DomainEntityDTOs.SongStyle>> AllAsyncWithInclude()
        {
            return await RepositoryDbSet
                .Include(ss => ss.Song)
                .Include(ss => ss.Style) 
                .Select(e => SongStyleMapper.MapFromDomain(e))
                .ToListAsync();
        }
        
        public async Task<DAL.App.DTO.DomainEntityDTOs.SongStyle> FindAsync(int id)
        {
            /*var songStyle = await base.FindAsync(id);
            if (songStyle != null)
            {
                await RepositoryDbContext.Entry(songStyle)
                    .Reference(ss => ss.Song).LoadAsync();
                await RepositoryDbContext.Entry(songStyle)
                    .Reference(ss => ss.Style).LoadAsync();
            }
            return songStyle;
            */

            var songStyle = await RepositoryDbSet
                .Include(ss => ss.Song)
                .Include(ss => ss.Style)
                .FirstOrDefaultAsync(ss => ss.Id == id);
            
            
            return SongStyleMapper.MapFromDomain(songStyle);
        }
    }
}