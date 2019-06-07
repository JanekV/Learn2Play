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

        #endregion

        public async Task<List<BLL.App.DTO.DomainEntityDTOs.Song>> SearchSongs(string search)
        {
            return (await Uow.Songs.SearchSongs(search)).Select(SongMapper.MapFromDAL).ToList();
        }

        public async Task<SongWithEverything> UpdateSongWithEverything(SongWithEverything swe)
        {
            var song = await Uow.Songs.FindDetachedAsync(swe.Id);
            song.Author = swe.SongAuthor;
            song.Name = swe.SongName;
            song.SpotifyLink = swe.SpotifyLink;
            song.Description = swe.SongDescription;
            Uow.Songs.Update(song);

            var songKey = await Uow.SongKeys.FindDetachedAsync(swe.SongKey.Id);
            songKey.Description = swe.SongKey.Description;
            Uow.SongKeys.Update(songKey);

            var songKeyNote = await Uow.Notes.FindDetachedAsync(songKey.NoteId);
            if (songKeyNote != null)
            {
                songKeyNote.Name = swe.SongKeyNoteName;
            }
            Uow.Notes.Update(songKeyNote);
            
            //:TODO move methods to more appropriate repos!
            await UpdateSongInstrumentsAsync(song, swe.Instruments);
            await UpdateSongStylesAsync(song, swe.Styles);
            await UpdateSongChordsAsync(song, swe.Chords);

            UpdateVideosAsync(song, swe.Videos);

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
        


        #region Move theeeseee
        private void UpdateVideosAsync(DAL.App.DTO.DomainEntityDTOs.Song song, IEnumerable<Video> videos)
        {
            foreach (var video in videos)
            {
                video.SongId = song.Id;
                Uow.Videos.Update(VideoMapper.MapFromBLL(video));
                /*foreach (var tab in video.Tabs)
                {
                    Uow.Tabs.Update(TabMapper.MapFromBLL(tab));
                }*/
            }
        }
        private async Task UpdateSongChordsAsync(DAL.App.DTO.DomainEntityDTOs.Song song, IEnumerable<Chord> chords)
        {
            foreach (var chord in chords)
            {
                var songChord = await Uow.SongChords.FindByChordAndSongIdAsync(chord.Id, song.Id);
                var chordFromDb = await Uow.Chords.FindDetachedAsync(chord.Id);
                if (chordFromDb == null)
                {
                    await Uow.Chords.AddAsync(ChordMapper.MapFromBLL(chord));
                }
                else
                {
                    Uow.Chords.Update(ChordMapper.MapFromBLL(chord));
                }
                if (songChord == null)
                {
                    await Uow.SongChords.AddAsync(new SongChord()
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
            DAL.App.DTO.DomainEntityDTOs.Song song, IEnumerable<DTO.DomainEntityDTOs.Style> styles)
        {
            foreach (var style in styles)
            {
                var songStyle = await Uow.SongStyles.FindByStyleAndSongIdAsync(style.Id, song.Id);
                var styleFromDb = await Uow.Styles.FindDetachedAsync(style.Id);
                if (styleFromDb == null)
                {
                    await Uow.Styles.AddAsync(StyleMapper.MapFromBLL(style));
                }
                else
                {
                    Uow.Styles.Update(StyleMapper.MapFromBLL(style));
                }
                if (songStyle == null)
                {
                    await Uow.SongStyles.AddAsync(new SongStyle()
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
                var instrumentFromDb = await Uow.Instruments.FindDetachedAsync(instrument.Id);
                if (instrumentFromDb == null)
                {
                    await Uow.Instruments.AddAsync(InstrumentMapper.MapFromBLL(instrument));
                }
                else
                {
                    Uow.Instruments.Update(InstrumentMapper.MapFromBLL(instrument));
                }
                if (songInstrument == null)
                {
                    
                    await Uow.SongInstruments.AddAsync(new SongInstrument()
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

        #endregion
    }
}