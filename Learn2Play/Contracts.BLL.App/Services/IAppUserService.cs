using Contracts.DAL.App.Repositories;
using Domain.Identity;
using ee.itcollege.javalg.Contracts.BLL.Base.Services;

namespace Contracts.BLL.App.Services
{
    public interface IAppUserService : IBaseEntityService<AppUser>, IAppUserRepository
    {
        
    }
}