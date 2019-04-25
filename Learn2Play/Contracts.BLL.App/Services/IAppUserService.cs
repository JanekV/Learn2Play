using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using Domain.Identity;

namespace Contracts.BLL.App.Services
{
    public interface IAppUserService : IBaseEntityService<AppUser>, IAppUserRepository
    {
        
    }
}