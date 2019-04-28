using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL.App.Services
{
    public class FolderService : BaseEntityService<BLL.App.DTO.DomainEntityDTOs.Folder, DAL.App.DTO.DomainEntityDTOs.Folder, IAppUnitOfWork>, IFolderService
    {
        public FolderService(IAppUnitOfWork uow) : base(uow, new FolderMapper())
        {
        }
    }
}