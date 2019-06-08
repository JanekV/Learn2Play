using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.App.DTO.DomainEntityDTOs;
using BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using DAL.App.DTO.DomainEntityDTOs;
using ee.itcollege.javalg.BLL.Base.Services;
using Chord = BLL.App.DTO.DomainEntityDTOs.Chord;
using Instrument = BLL.App.DTO.DomainEntityDTOs.Instrument;
using Note = DAL.App.DTO.DomainEntityDTOs.Note;
using Song = BLL.App.DTO.DomainEntityDTOs.Song;
using SongChord = DAL.App.DTO.DomainEntityDTOs.SongChord;
using SongInstrument = DAL.App.DTO.DomainEntityDTOs.SongInstrument;
using SongStyle = DAL.App.DTO.DomainEntityDTOs.SongStyle;
using Style = DAL.App.DTO.DomainEntityDTOs.Style;
using Video = BLL.App.DTO.DomainEntityDTOs.Video;

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

        #region Get song with everything

        public async Task<SongWithEverything> GetSongWithEverythingAsync(int songId)
        {
            var song = SongMapper.MapFromDAL(await Uow.Songs.GetSongWithEverythingAsync(songId));
            song.Styles = (await Uow.Styles.GetStylesForIds(song.StyleIds)).ConvertAll(StyleMapper.MapFromDAL);
            foreach (var video in song.Videos)
            {
                video.Tabs = (Uow.Tabs.AllAsync().Result.Where(t => t.VideoId == video.Id).ToList()
                    .ConvertAll(TabMapper.MapFromDAL));
            }
            song.Instruments = (await Uow.Instruments.GetInstrumentsForIds(song.InstrumentIds)).ConvertAll(InstrumentMapper.MapFromDAL);
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

        #endregion

        public async Task<List<BLL.App.DTO.DomainEntityDTOs.Song>> SearchSongs(string search)
        {
            return (await Uow.Songs.SearchSongs(search)).Select(SongMapper.MapFromDAL).ToList();
        }

        public async Task<SongWithEverything> UpdateSongWithEverything(SongWithEverything swe)
        {
            var song = await Uow.Songs.FindDetachedAsync(swe.Id);
            var songKey = await Uow.SongKeys.FindDetachedAsync(swe.SongKeyId);
            song.Author = swe.SongAuthor;
            song.Name = swe.SongName;
            song.SpotifyLink = swe.SpotifyLink;
            song.Description = swe.SongDescription;
            song.SongKeyId = swe.SongKeyId;
            song.SongKey = songKey;
            Uow.Songs.Update(song);


            var songKeyNote = await Uow.Notes.FindDetachedAsync(songKey.NoteId);

            Uow.Notes.Update(songKeyNote);
            
            return swe;
        }

        public async Task AddInstrumentToSongAsync(Song song, Instrument instrument)
        {
            var songInstrument = new SongInstrument()
            {
                SongId = song.Id,
                Song = SongMapper.MapFromBLL(song),
                InstrumentId = instrument.Id,
                Instrument = InstrumentMapper.MapFromBLL(instrument)
            };
            await Uow.SongInstruments.AddAsync(songInstrument);
        }

        public async Task AddChordToSongAsync(
            BLL.App.DTO.DomainEntityDTOs.Song song, Chord chord)
        {
            var songChord = new SongChord()
            {
                SongId = song.Id,
                Song = SongMapper.MapFromBLL(song),
                ChordId = chord.Id,
                Chord = ChordMapper.MapFromBLL(chord)
            };
            await Uow.SongChords.AddAsync(songChord);
        }

        public async Task AddVideoToSongAsync(Song song, Video video)
        {
            video.Song = song;
            video.SongId = song.Id;
            await Uow.Videos.AddAsync(VideoMapper.MapFromBLL(video));
        }

        public async Task AddStyleToSongAsync(
            BLL.App.DTO.DomainEntityDTOs.Song song, BLL.App.DTO.DomainEntityDTOs.Style style)
        {
            var songStyle = new SongStyle()
            {
                SongId = song.Id,
                Song = SongMapper.MapFromBLL(song),
                StyleId = style.Id,
                Style = StyleMapper.MapFromBLL(style)
            };
            await Uow.SongStyles.AddAsync(songStyle);
        }
    }
}