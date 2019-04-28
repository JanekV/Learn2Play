using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using BLLAppDTO = BLL.App.DTO.DomainEntityDTOs;

namespace Contracts.BLL.App.Services
{
    public interface IFolderService : IBaseEntityService<BLLAppDTO.Folder>, IFolderRepository<BLLAppDTO.Folder>
    {
        
    }
}