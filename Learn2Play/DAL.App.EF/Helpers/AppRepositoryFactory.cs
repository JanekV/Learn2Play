using Contracts.DAL.App.Repositories;
using DAL.App.EF.Repositories;
using DAL.Base.EF.Helpers;
using DAL.Repositories;

namespace DAL.App.EF.Helpers
{
    public class AppRepositoryFactory: BaseRepositoryFactory

    {
        public AppRepositoryFactory()
        {
            RepositoryCreationMethods.Add(typeof(IAppUserRepository),
                dataContext => new AppUserRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IChordNoteRepository),
                dataContext => new ChordNoteRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IChordRepository),
                dataContext => new ChordRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IFolderRepository),
                dataContext => new FolderRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IInstrumentRepository),
                dataContext => new InstrumentRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(INoteRepository),
                dataContext => new NoteRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(ISongChordRepository),
                dataContext => new SongChordRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(ISongInFolderRepository),
                dataContext => new SongInFolderRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(ISongInstrumentRepository),
                dataContext => new SongInstrumentRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(ISongKeyRepository),
                dataContext => new SongKeyRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(ISongRepository),
                dataContext => new SongRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(ISongStyleRepository),
                dataContext => new SongStyleRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IStyleRepository),
                dataContext => new StyleRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(ITabRepository),
                dataContext => new TabRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(ITuningNoteRepository),
                dataContext => new TuningNoteRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IUserFolderRepository),
                dataContext => new UserFolderRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IUserInstrumentRepository),
                dataContext => new UserInstrumentRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(IVideoRepository),
                dataContext => new VideoRepository(dataContext));
        }
    }
}