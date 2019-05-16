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
    public class UserInstrumentRepository: BaseRepository<DAL.App.DTO.DomainEntityDTOs.UserInstrument, Domain.UserInstrument, AppDbContext>, IUserInstrumentRepository
    {
        public UserInstrumentRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new UserInstrumentMapper())
        {
        }

        public async Task<List<DAL.App.DTO.DomainEntityDTOs.UserInstrument>> AllAsyncWithInclude()
        {
            return await RepositoryDbSet
                .Include(uf => uf.AppUser)
                .Include(uf => uf.Instrument)
                .Select(e => UserInstrumentMapper.MapFromDomain(e))
                .ToListAsync();
        }
        
        public async Task<DAL.App.DTO.DomainEntityDTOs.UserInstrument> FindAsync(int id)
        {
            /*var userInstrument = await base.FindAsync(id);
            if (userInstrument != null)
            {
                await RepositoryDbContext.Entry(userInstrument)
                    .Reference(ui => ui.AppUser).LoadAsync();
                await RepositoryDbContext.Entry(userInstrument)
                    .Reference(ui => ui.Instrument).LoadAsync();
            }
            
            
            return userInstrument;*/
            
            var userInstrument = await RepositoryDbSet
                .Include(ui => ui.AppUser)
                .Include(ui => ui.Instrument)
                .FirstOrDefaultAsync(ui => ui.Id == id);
            
            
            return UserInstrumentMapper.MapFromDomain(userInstrument);
        }
    }
}