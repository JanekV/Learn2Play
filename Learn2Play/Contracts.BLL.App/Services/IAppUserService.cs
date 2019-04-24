using Contracts.DAL.App.Repositories;
using Contrtacts.BLL.Base.Services;
using Domain.Identity;

namespace Contracts.BLL.App.Services
{
    public interface IAppUserService : IBaseEntityService<AppUser>, IAppUserRepository
    {
        
    }
}