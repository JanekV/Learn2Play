using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.App.DTO.DomainEntityDTOs;
using ee.itcollege.javalg.Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface ISongKeyRepository : ISongKeyRepository<DALAppDTO.DomainEntityDTOs.SongKey>
    {
        Task<DALAppDTO.DomainEntityDTOs.SongKey> FindAsyncWithIncludeAsync(int id);
        Task<SongKey> FindDetachedAsync(int id);
    }
    public interface ISongKeyRepository<TDALEntity>: IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    {
        Task<List<TDALEntity>> AllAsyncWithInclude();
    }
}