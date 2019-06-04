using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.javalg.Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using BLL.App.DTO;
using BLLAppDTO = BLL.App.DTO.DomainEntityDTOs;

namespace Contracts.BLL.App.Services
{
    public interface ISongService : IBaseEntityService<BLLAppDTO.Song>, ISongRepository<BLLAppDTO.Song>
    {
        Task<SongWithEverything> GetSongWithEverythingAsync(int songId);
        Task<List<SongWithEverything>> GetAllSongsWithEverythingAsync();
        Task<List<BLLAppDTO.Song>> SearchSongs(string search);
    }
}