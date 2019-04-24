using Contracts.DAL.App.Repositories;
using Contrtacts.BLL.Base.Services;
using Domain;

namespace Contracts.BLL.App.Services
{
    public interface IUserFolderService : IBaseEntityService<UserFolder>, IUserFolderRepository
    {
        
    }
}