using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.App.DTO.DomainEntityDTOs;
using BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using ee.itcollege.javalg.BLL.Base.Services;

namespace BLL.App.Services
{
    public class SongService : BaseEntityService<BLL.App.DTO.DomainEntityDTOs.Song, DAL.App.DTO.DomainEntityDTOs.Song, IAppUnitOfWork>, ISongService
    {
        public SongService(IAppUnitOfWork uow) : base(uow, new SongMapper())
        {
            ServiceRepository = Uow.Songs;
        }

        public async Task<List<BLL.App.DTO.DomainEntityDTOs.Song>> AllAsyncWithInclude()
        {
            return (await Uow.Songs.AllAsyncWithInclude()).Select(SongMapper.MapFromDAL).ToList();
        }

        public async Task<SongWithEverything> GetSongWithEverythingAsync(int songId)
        {
            var song = SongMapper.MapFromDAL(await Uow.Songs.GetSongWithEverythingAsync(songId));
            song.Styles = Uow.Styles.GetStylesForIds(song.StyleIds).Result.ConvertAll(StyleMapper.MapFromDAL);
            return song;
        }

        public async Task<List<SongWithEverything>> GetAllSongsWithEverythingAsync()
        {
            var songs = (await Uow.Songs.GetAllSongsWithEverythingAsync()).Select(SongMapper.MapFromDAL).ToList();
            foreach (var song in songs)
            {
                song.Styles = Uow.Styles.GetStylesForIds(song.StyleIds).Result.ConvertAll(StyleMapper.MapFromDAL);
            }
            return songs;
        }

        public async Task<List<BLL.App.DTO.DomainEntityDTOs.Song>> SearchSongs(string search)
        {
            return (await Uow.Songs.SearchSongs(search)).Select(SongMapper.MapFromDAL).ToList();
        }
    }
}