using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using ee.itcollege.javalg.DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Song = DAL.App.DTO.DomainEntityDTOs.Song;

namespace DAL.App.EF.Repositories
{
    public class SongRepository: BaseRepository<DAL.App.DTO.DomainEntityDTOs.Song, Domain.Song, AppDbContext>, ISongRepository
    {
        public SongRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new SongMapper())
        {
        }

        public async Task<List<DAL.App.DTO.DomainEntityDTOs.Song>> AllAsyncWithInclude()
        {
            return await RepositoryDbSet
                .Include(s => s.SongKey)
                .ThenInclude(sk => sk.Description)
                .ThenInclude(m => m.Translations)
                .Select(e => SongMapper.MapFromDomain(e))
                .ToListAsync();
        }

        public async Task<SongWithEverything> GetSongWithEverythingAsync(int songId)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            var res = await RepositoryDbSet
                .Where(s => s.Id == songId)
                .Select(s => new
                {
                    Id = s.Id,
                    SongName = s.Name,
                    SongAuthor = s.Author,
                    SpotifyLink = s.SpotifyLink,
                    SongDescription = s.Description,
                    SongKey = s.SongKey,
                    SongKeyId = s.SongKey.Id,
                    SongKeyNoteName = s.SongKey.Note.Name,
                    SongKeyDescription = s.SongKey.Description,
                    FoldersCount = s.SongInFolders.Count,
                    InstrumentIds = s.SongInstruments
                        .Select(si => si.Instrument.Id).ToList(),
                    StyleIds = s.SongStyles
                        .Select(ss => ss.Style.Id).ToList(),
                    Chords = s.SongChords
                        .Select(sc => sc.Chord).ToList(),
                    Videos = s.Videos.ToList(),
                }).FirstOrDefaultAsync();

            var swe = new SongWithEverything()
            {
                Id = res.Id,
                SongName = res.SongName,
                SongAuthor = res.SongAuthor,
                SpotifyLink = res.SpotifyLink,
                SongDescription = res.SongDescription,
                SongKey = SongKeyMapper.MapFromDomain(res.SongKey),
                SongKeyId = res.SongKeyId,
                SongKeyNoteName = res.SongKeyNoteName,
                SongKeyDescription = res.SongKeyDescription.Translate(),
                FoldersCount = res.FoldersCount,
                InstrumentIds = res.InstrumentIds,
                StyleIds = res.StyleIds,
                Chords = res.Chords.ConvertAll(ChordMapper.MapFromDomain),
                Videos = res.Videos.ConvertAll(VideoMapper.MapFromDomain),
        };
            return swe;
        }

        public async Task<List<SongWithEverything>> GetAllSongsWithEverythingAsync()
        {
            var res = await RepositoryDbSet
                .Select(s => new
                {
                    Id = s.Id,
                    SongName = s.Name,
                    SongAuthor = s.Author,
                    SpotifyLink = s.SpotifyLink,
                    SongDescription = s.Description,
                    SongKeyId = s.SongKeyId,
                    SongKeyNoteName = s.SongKey.Note.Name,
                    SongKeyDescription = s.SongKey.Description,
                    FoldersCount = s.SongInFolders.Count,
                    Instruments = s.SongInstruments
                        .Select(si => si.Instrument).ToList(),
                    StyleIds = s.SongStyles
                        .Select(ss => ss.Style.Id).ToList(),
                    Chords = s.SongChords
                        .Select(sc => sc.Chord).ToList(),
                    Videos = s.Videos.ToList(),
                }).ToListAsync();
            
            var resultList = res.Select(s => new SongWithEverything()
            {
                Id = s.Id,
                SongName = s.SongName,
                SongAuthor = s.SongAuthor,
                SpotifyLink = s.SpotifyLink,
                SongDescription = s.SongDescription,
                SongKeyId = s.SongKeyId,
                SongKeyNoteName = s.SongKeyNoteName,
                SongKeyDescription = s.SongKeyDescription.Translate(),
                FoldersCount = s.FoldersCount,
                Instruments = s.Instruments.ConvertAll(InstrumentMapper.MapFromDomain),
                StyleIds = s.StyleIds,
                Chords = s.Chords.ConvertAll(ChordMapper.MapFromDomain),
                Videos = s.Videos.ConvertAll(VideoMapper.MapFromDomain),
            }).ToList();

            return resultList;
        }

        public async Task<List<DAL.App.DTO.DomainEntityDTOs.Song>> SearchSongs(string search)
        {
            var query = RepositoryDbSet
                .Include(s => s.SongInstruments)
                .Include(s => s.SongStyles)
                .AsQueryable();
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToUpper().Trim();
                query = query
                    .Where(s =>
                        s.Name.ToUpper().Contains(search) ||
                        s.Author.ToUpper().Contains(search) ||
                        s.SongInstruments.Any(si =>
                            si.Instrument.Name
                                .Translations
                                .Any(t => t.Value.ToUpper().Contains(search))) ||
                        s.SongStyles.Any(ss =>
                            ss.Style.Name.Translations.Any(t =>
                                t.Value.ToUpper().Contains(search))));
            }

            return await query.Select(s => SongMapper.MapFromDomain(s)).ToListAsync();
        }

        public async Task<Song> FindDetachedAsync(int id)
        {
            
            var songEntry = RepositoryDbContext.Entry(await RepositoryDbSet.FindAsync(id));
            if (songEntry != null)
            {
                songEntry.State = EntityState.Detached;
                var song = songEntry.Entity;
                return SongMapper.MapFromDomain(song);
            }
            return null;
        }

        public async Task<DAL.App.DTO.DomainEntityDTOs.Song> FindAsync(int id)
        {
            var song = await RepositoryDbSet
                .Include(s => s.SongKey)
                .FirstOrDefaultAsync(s => s.Id == id);
            return SongMapper.MapFromDomain(song);
        }
    }
}