using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class UserInstrumentRepository: BaseRepository<UserInstrument>, IUserInstrumentRepository
    {
        public UserInstrumentRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public async Task<IEnumerable<UserInstrument>> AllAsyncWithInclude()
        {
            return await RepositoryDbSet
                .Include(uf => uf.AppUser)
                .Include(uf => uf.Instrument)
                .ToListAsync();
        }
        
        public override async Task<UserInstrument> FindAsync(params object[] id)
        {
            var userInstrument = await base.FindAsync(id);
            if (userInstrument != null)
            {
                await RepositoryDbContext.Entry(userInstrument)
                    .Reference(ui => ui.AppUser).LoadAsync();
                await RepositoryDbContext.Entry(userInstrument)
                    .Reference(ui => ui.Instrument).LoadAsync();
            }
            
            
            return userInstrument;
        }
    }
}