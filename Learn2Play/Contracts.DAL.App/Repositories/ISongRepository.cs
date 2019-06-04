using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using ee.itcollege.javalg.Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface ISongRepository : ISongRepository<DALAppDTO.DomainEntityDTOs.Song>
    {
        Task<DALAppDTO.SongWithEverything> GetSongWithEverythingAsync(int songId);
        Task<List<DALAppDTO.SongWithEverything>> GetAllSongsWithEverythingAsync();
        Task<List<DALAppDTO.DomainEntityDTOs.Song>> SearchSongs(string search);
    }
    public interface ISongRepository<TDALEntity>: IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    {
        Task<List<TDALEntity>> AllAsyncWithInclude();
    }
}