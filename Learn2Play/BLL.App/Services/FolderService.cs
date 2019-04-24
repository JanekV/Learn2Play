using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class FolderService : BaseEntityService<Folder, IAppUnitOfWork>, IFolderService
    {
        public FolderService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}