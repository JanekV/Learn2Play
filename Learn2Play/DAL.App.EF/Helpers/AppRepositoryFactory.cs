using Contracts.DAL.App.Repositories;
using DAL.App.EF.Repositories;
using DAL.Base.EF.Helpers;

namespace DAL.App.EF.Helpers
{
    public class AppRepositoryFactory: BaseRepositoryFactory<AppDbContext>

    {
        public AppRepositoryFactory()
        {
            RegisterRepositories();
        }
        
        private void RegisterRepositories()
        {
            AddToCreationMethods<IAppUserRepository>(dataContext => new AppUserRepository(dataContext));
            AddToCreationMethods<IChordNoteRepository>(dataContext => new ChordNoteRepository(dataContext));
            AddToCreationMethods<IChordRepository>(dataContext => new ChordRepository(dataContext));            
            AddToCreationMethods<IFolderRepository>(dataContext => new FolderRepository(dataContext));
            AddToCreationMethods<IInstrumentRepository>(dataContext => new InstrumentRepository(dataContext));
            AddToCreationMethods<INoteRepository>(dataContext => new NoteRepository(dataContext));
            AddToCreationMethods<ISongChordRepository>(dataContext => new SongChordRepository(dataContext));
            AddToCreationMethods<ISongInFolderRepository>(dataContext => new SongInFolderRepository(dataContext));
            AddToCreationMethods<ISongInstrumentRepository>(dataContext => new SongInstrumentRepository(dataContext));
            AddToCreationMethods<ISongKeyRepository>(dataContext => new SongKeyRepository(dataContext));
            AddToCreationMethods<ISongRepository>(dataContext => new SongRepository(dataContext));
            AddToCreationMethods<ISongStyleRepository>(dataContext => new SongStyleRepository(dataContext));
            AddToCreationMethods<IStyleRepository>(dataContext => new StyleRepository(dataContext));
            AddToCreationMethods<ITabRepository>(dataContext => new TabRepository(dataContext));
            AddToCreationMethods<ITuningNoteRepository>(dataContext => new TuningNoteRepository(dataContext));
            AddToCreationMethods<IUserFolderRepository>(dataContext => new UserFolderRepository(dataContext));
            AddToCreationMethods<IUserInstrumentRepository>(dataContext => new UserInstrumentRepository(dataContext));
            AddToCreationMethods<IVideoRepository>(dataContext => new VideoRepository(dataContext));

        }

    }
}