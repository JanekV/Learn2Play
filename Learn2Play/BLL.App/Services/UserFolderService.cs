using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class UserFolderService : BaseEntityService<UserFolder, IAppUnitOfWork>, IUserFolderService
    {
        public UserFolderService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<IEnumerable<UserFolder>> AllAsyncWithInclude()
        {
            return await Uow.UserFolders.AllAsyncWithInclude();
        }
    }
}