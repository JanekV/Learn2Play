using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class TabRepository: BaseRepository<Tab>, ITabRepository
    {
        public TabRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public async Task<IEnumerable<Tab>> AllAsyncWithInclude()
        {
            return await RepositoryDbSet
                .Include(t => t.Video)
                .ToListAsync();
        }
        
        public override async Task<Tab> FindAsync(params object[] id)
        {
            var tab = await base.FindAsync(id);
            if (tab != null)
            {
                await RepositoryDbContext.Entry(tab)
                    .Reference(t => t.Video).LoadAsync();
            }
            return tab;
        }
    }
}