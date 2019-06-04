using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.javalg.Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{  
    public interface ISongInstrumentRepository : ISongInstrumentRepository<DALAppDTO.DomainEntityDTOs.SongInstrument>
    {
        Task<DALAppDTO.DomainEntityDTOs.SongInstrument> FindByInstrumentAndSongIdAsync(int instrumentId, int songId);

    }
    public interface ISongInstrumentRepository<TDALEntity>: IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    {
        Task<List<TDALEntity>> AllAsyncWithInclude();
    }
}