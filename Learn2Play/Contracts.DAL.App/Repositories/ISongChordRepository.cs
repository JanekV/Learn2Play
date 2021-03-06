using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.App.DTO.DomainEntityDTOs;
using ee.itcollege.javalg.Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{   
    public interface ISongChordRepository : ISongChordRepository<DALAppDTO.DomainEntityDTOs.SongChord>
    { 
        Task<SongChord> FindByChordAndSongIdAsync(int chordId, int songId);
    }
    public interface ISongChordRepository<TDALEntity>: IBaseRepository<TDALEntity>
        where TDALEntity : class, new()
    {
        Task<List<TDALEntity>> AllAsyncWithInclude();
    }
}