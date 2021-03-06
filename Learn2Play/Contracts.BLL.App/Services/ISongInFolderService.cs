using ee.itcollege.javalg.Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using BLLAppDTO = BLL.App.DTO.DomainEntityDTOs;

namespace Contracts.BLL.App.Services
{
    public interface ISongInFolderService : IBaseEntityService<BLLAppDTO.SongInFolder>, ISongInFolderRepository<BLLAppDTO.SongInFolder>
    {
        void RemoveSong(int folderId, int songId);
    }
}