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
    public class TabRepository: BaseRepository<DAL.App.DTO.DomainEntityDTOs.Tab, Domain.Tab, AppDbContext>, ITabRepository
    {
        public TabRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new TabMapper())
        {
        }

        public async Task<List<DAL.App.DTO.DomainEntityDTOs.Tab>> AllAsyncWithInclude()
        {
            return await RepositoryDbSet
                .Include(t => t.Video)
                .Select(e => TabMapper.MapFromDomain(e))
                .ToListAsync();
        }
        
        public async Task<DAL.App.DTO.DomainEntityDTOs.Tab> FindAsync(int id)
        {
            /*var tab = await base.FindAsync(id);
            if (tab != null)
            {
                await RepositoryDbContext.Entry(tab)
                    .Reference(t => t.Video).LoadAsync();
            }
            return tab;
            */

            var tab = await RepositoryDbSet
                .Include(t => t.Video)
                .FirstOrDefaultAsync(t => t.Id == id);
            
            
            return TabMapper.MapFromDomain(tab);
        }
    }
}