using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.javalg.Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{   
    public interface ISongInFolderRepository : ISongInFolderRepository<DALAppDTO.DomainEntityDTOs.SongInFolder>
    {
        void RemoveSong(int folderId, int songId);
    }
    public interface ISongInFolderRepository<TDALEntity>: IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    {
        Task<List<TDALEntity>> AllAsyncWithInclude();
    }
}