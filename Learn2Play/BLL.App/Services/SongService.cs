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
using Song = BLL.App.DTO.DomainEntityDTOs.Song;
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

        public async Task<SongWithEverything> GetSongWithEverythingAsync(int songId)
        {
            var song = SongMapper.MapFromDAL(await Uow.Songs.GetSongWithEverythingAsync(songId));
            song.Styles = Uow.Styles.GetStylesForIds(song.StyleIds).Result.ConvertAll(StyleMapper.MapFromDAL);
            foreach (var video in song.Videos)
            {
                video.Tabs = (Uow.Tabs.AllAsync().Result.Where(t => t.VideoId == video.Id).ToList()
                    .ConvertAll(TabMapper.MapFromDAL));
            }
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

        public async Task<SongWithEverything> UpdateSongWithEverything(SongWithEverything swe)
        {
            var song = await Uow.Songs.FindAsync(swe.Id);
            song.Author = swe.SongAuthor;
            song.Name = swe.SongName;
            song.SpotifyLink = swe.SpotifyLink;
            song.Description = swe.SongDescription;
            Uow.Songs.Update(song);

            var songKey = await Uow.SongKeys.FindAsync(swe.SongKeyId);
            songKey.Description = swe.SongKeyDescription;
            Uow.SongKeys.Update(songKey);

            var songKeyNote = await Uow.Notes.FindAsync(songKey.Note.Id);
            if (songKeyNote != null)
            {
                songKeyNote.Name = swe.SongKeyNoteName;
            }
            Uow.Notes.Update(songKeyNote);
            
            //:TODO move methods to more appropriate repos!
            await UpdateSongInstrumentsAsync(song, swe.Instruments);
            await UpdateSongStylesAsync(song, swe.Styles);
            await UpdateSongChordsAsync(song, swe.Chords);

            UpdateVideosAsync(swe.Videos);

            return swe;
        }

        private void UpdateVideosAsync(IEnumerable<Video> videos)
        {
            foreach (var video in videos)
            {
                Uow.Videos.Update(VideoMapper.MapFromBLL(video));
                foreach (var tab in video.Tabs)
                {
                    Uow.Tabs.Update(TabMapper.MapFromBLL(tab));
                }
            }
        }

        private async Task UpdateSongChordsAsync(DAL.App.DTO.DomainEntityDTOs.Song song, IEnumerable<Chord> chords)
        {
            foreach (var chord in chords)
            {
                var songChord = await Uow.SongChords.FindByStyleAndSongIdAsync(chord.Id, song.Id);
                if (songChord == null)
                {
                    await Uow.SongChords.AddAsync(new DAL.App.DTO.DomainEntityDTOs.SongChord()
                    {
                        Song = song,
                        SongId = song.Id,
                        Chord = ChordMapper.MapFromBLL(chord),
                        ChordId = chord.Id
                    });
                }
                Uow.SongChords.Update(songChord);
            }
        }

        private async Task UpdateSongStylesAsync(
            DAL.App.DTO.DomainEntityDTOs.Song song, IEnumerable<BLL.App.DTO.DomainEntityDTOs.Style> styles)
        {
            foreach (var style in styles)
            {
                var songStyle = await Uow.SongStyles.FindByStyleAndSongIdAsync(style.Id, song.Id);
                if (songStyle == null)
                {
                    await Uow.SongStyles.AddAsync(new DAL.App.DTO.DomainEntityDTOs.SongStyle()
                    {
                        Song = song,
                        SongId = song.Id,
                        Style = StyleMapper.MapFromBLL(style),
                        StyleId = style.Id
                    });
                }
                Uow.SongStyles.Update(songStyle);
            }
        }

        private async Task UpdateSongInstrumentsAsync(DAL.App.DTO.DomainEntityDTOs.Song song, IEnumerable<Instrument> instruments)
        {
            foreach (var instrument in instruments)
            {
                var songInstrument = await Uow.SongInstruments.FindByInstrumentAndSongIdAsync(instrument.Id, song.Id);
                if (songInstrument == null)
                {
                    await Uow.SongInstruments.AddAsync(new DAL.App.DTO.DomainEntityDTOs.SongInstrument()
                    {
                        Song = song,
                        SongId = song.Id,
                        Instrument = InstrumentMapper.MapFromBLL(instrument),
                        InstrumentId = instrument.Id
                    });
                }
                Uow.SongInstruments.Update(songInstrument);
            }
        }
    }
}