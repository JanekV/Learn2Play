using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base.Repositories;
using DAL.Base.EF.Repositories;
using DAL.Repositories;

namespace DAL
{
    public class AppUnitOfWork: IAppUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        
        // repo cache
        private readonly Dictionary<Type, object> _repositoryCache = new Dictionary<Type, object>();

        public IChordRepository Chords =>
            GetOrCreateRepository(dataContext => new ChordRepository(dataContext));
        
        public IChordNoteRepository ChordNotes =>
            GetOrCreateRepository(dataContext => new ChordNoteRepository(dataContext));

        public IFolderRepository Folders =>
            GetOrCreateRepository(dataContext => new FolderRepository(dataContext));

        public IInstrumentRepository Instruments =>
            GetOrCreateRepository(dataContext => new InstrumentRepository(dataContext));

        public INoteRepository Notes =>
            GetOrCreateRepository(dataContext => new NoteRepository(dataContext));

        public ISongRepository Songs =>
            GetOrCreateRepository(dataContext => new SongRepository(dataContext));

        public ISongChordRepository SongChords =>
            GetOrCreateRepository(dataContext => new SongChordRepository(dataContext));

        public ISongInFolderRepository SongInFolders =>
            GetOrCreateRepository(dataContext => new SongInFolderRepository(dataContext));

        public ISongInstrumentRepository SongInstruments =>
            GetOrCreateRepository(dataContext => new SongInstrumentRepository(dataContext));

        public ISongKeyRepository SongKeys =>
            GetOrCreateRepository(dataContext => new SongKeyRepository(dataContext));

        public ISongStyleRepository SongStyles =>
            GetOrCreateRepository(dataContext => new SongStyleRepository(dataContext));

        public IStyleRepository Styles =>
            GetOrCreateRepository(dataContext => new StyleRepository(dataContext));

        public ITabRepository Tabs =>
            GetOrCreateRepository(dataContext => new TabRepository(dataContext));

        public ITuningNoteRepository TuningNotes =>
            GetOrCreateRepository(dataContext => new TuningNoteRepository(dataContext));

        public IUserFolderRepository UserFolders =>
            GetOrCreateRepository(dataContext => new UserFolderRepository(dataContext));

        public IUserInstrumentRepository UserInstruments =>
            GetOrCreateRepository(dataContext => new UserInstrumentRepository(dataContext));

        public IVideoRepository Videos =>
            GetOrCreateRepository(dataContext => new VideoRepository(dataContext));



        
        public IBaseRepository<TEntity> BaseRepository<TEntity>() where TEntity : class, new() => 
            GetOrCreateRepository((dataContext) => new BaseRepository<TEntity>(dataContext));

        public AppUnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        private TRepository GetOrCreateRepository<TRepository>(Func<AppDbContext, TRepository> factoryMethod)
        {
            // try to get repo by type from cache dictionary
            _repositoryCache.TryGetValue(typeof(TRepository), out var repoObject);
            if (repoObject != null)
            {
                // we have it, cat it to correct type and return
                return (TRepository) repoObject;
            }

            // call the factory method to actually create the repo object
            repoObject = factoryMethod(_appDbContext);
            // add it to cache
            _repositoryCache[typeof(TRepository)] = repoObject;
            return (TRepository) repoObject;
        }

        
        public virtual int SaveChanges()
        {
            return _appDbContext.SaveChanges();
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }

        
    }
}