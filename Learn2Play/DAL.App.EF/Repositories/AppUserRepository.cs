using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain.Identity;

namespace DAL.App.EF.Repositories
{
    public class AppUserRepository: BaseRepository<AppUser, AppDbContext>, IAppUserRepository
    {
        public AppUserRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}