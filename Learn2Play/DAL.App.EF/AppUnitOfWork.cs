using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using ee.itcollege.javalg.Contracts.DAL.Base.Helpers;
using ee.itcollege.javalg.DAL.Base.EF;


namespace DAL.App.EF
{
    public class AppUnitOfWork: BaseUnitOfWork<AppDbContext>, IAppUnitOfWork
    {
        public AppUnitOfWork(AppDbContext dbContext, IBaseRepositoryProvider repositoryProvider): base(dbContext, repositoryProvider)
        {
        }

        /*public IAppUserRepository AppUsers =>
            _repositoryProvider.GetRepository<IAppUserRepository>();*/
        public IChordRepository Chords =>
            _repositoryProvider.GetRepository<IChordRepository>();
        public IChordNoteRepository ChordNotes =>
            _repositoryProvider.GetRepository<IChordNoteRepository>();
        public IFolderRepository Folders =>
            _repositoryProvider.GetRepository<IFolderRepository>();
        public IInstrumentRepository Instruments =>
            _repositoryProvider.GetRepository<IInstrumentRepository>();
        public INoteRepository Notes =>
            _repositoryProvider.GetRepository<INoteRepository>();
        public ISongRepository Songs =>
            _repositoryProvider.GetRepository<ISongRepository>();
        public ISongChordRepository SongChords =>
            _repositoryProvider.GetRepository<ISongChordRepository>();
        public ISongInFolderRepository SongInFolders =>
            _repositoryProvider.GetRepository<ISongInFolderRepository>();
        public ISongInstrumentRepository SongInstruments =>
            _repositoryProvider.GetRepository<ISongInstrumentRepository>();
        public ISongKeyRepository SongKeys =>
            _repositoryProvider.GetRepository<ISongKeyRepository>();
        public ISongStyleRepository SongStyles =>
            _repositoryProvider.GetRepository<ISongStyleRepository>();
        public IStyleRepository Styles =>
            _repositoryProvider.GetRepository<IStyleRepository>();

        public ITabRepository Tabs =>
            _repositoryProvider.GetRepository<ITabRepository>();
        public ITuningNoteRepository TuningNotes =>
            _repositoryProvider.GetRepository<ITuningNoteRepository>();
        public IUserFolderRepository UserFolders =>
            _repositoryProvider.GetRepository<IUserFolderRepository>();
        public IUserInstrumentRepository UserInstruments =>
            _repositoryProvider.GetRepository<IUserInstrumentRepository>();
        public IVideoRepository Videos =>
            _repositoryProvider.GetRepository<IVideoRepository>();    
    }
}