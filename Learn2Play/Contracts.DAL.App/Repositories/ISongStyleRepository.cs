using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.javalg.Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{  
    public interface ISongStyleRepository : ISongStyleRepository<DALAppDTO.DomainEntityDTOs.SongStyle>
    {
        Task<DALAppDTO.DomainEntityDTOs.SongStyle> FindByStyleAndSongIdAsync(int styleId, int songId);

    }
    public interface ISongStyleRepository<TDALEntity>: IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    {
        Task<List<TDALEntity>> AllAsyncWithInclude();
    }
}