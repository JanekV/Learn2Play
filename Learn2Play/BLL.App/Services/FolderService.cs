using BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using ee.itcollege.javalg.BLL.Base.Services;

namespace BLL.App.Services
{
    public class FolderService : BaseEntityService<BLL.App.DTO.DomainEntityDTOs.Folder, DAL.App.DTO.DomainEntityDTOs.Folder, IAppUnitOfWork>, IFolderService
    {
        public FolderService(IAppUnitOfWork uow) : base(uow, new FolderMapper())
        {
            ServiceRepository = Uow.Folders;
        }
    }
}