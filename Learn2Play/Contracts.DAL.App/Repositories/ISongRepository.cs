using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using ee.itcollege.javalg.Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;
using Song = DAL.App.DTO.DomainEntityDTOs.Song;

namespace Contracts.DAL.App.Repositories
{
    public interface ISongRepository : ISongRepository<DALAppDTO.DomainEntityDTOs.Song>
    {
        Task<DALAppDTO.SongWithEverything> GetSongWithEverythingAsync(int songId);
        Task<List<DALAppDTO.SongWithEverything>> GetAllSongsWithEverythingAsync();
        Task<List<DALAppDTO.DomainEntityDTOs.Song>> SearchSongs(string search);
        Task<Song> FindDetachedAsync(int id);
    }
    public interface ISongRepository<TDALEntity>: IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    {
        Task<List<TDALEntity>> AllAsyncWithInclude();
    }
}