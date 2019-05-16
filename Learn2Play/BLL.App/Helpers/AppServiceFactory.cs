using BLL.App.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using ee.itcollege.javalg.BLL.Base.Helpers;
using ee.itcollege.javalg.Contracts.BLL.Base.Helpers;

namespace BLL.App.Helpers
{
    public class AppServiceFactory : BaseServiceFactory<IAppUnitOfWork>, IBaseServiceFactory<IAppUnitOfWork>
    {
        public AppServiceFactory()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            // Register all your custom services here!
            //AddToCreationMethods<IAppUserService>(uow => new AppUserService(uow));
            AddToCreationMethods<IChordNoteService>(uow => new ChordNoteService(uow));
            AddToCreationMethods<IChordService>(uow => new ChordService(uow));            
            AddToCreationMethods<IFolderService>(uow => new FolderService(uow));
            AddToCreationMethods<IInstrumentService>(uow => new InstrumentService(uow));
            AddToCreationMethods<INoteService>(uow => new NoteService(uow));
            AddToCreationMethods<ISongChordService>(uow => new SongChordService(uow));
            AddToCreationMethods<ISongInFolderService>(uow => new SongInFolderService(uow));
            AddToCreationMethods<ISongInstrumentService>(uow => new SongInstrumentService(uow));
            AddToCreationMethods<ISongKeyService>(uow => new SongKeyService(uow));
            AddToCreationMethods<ISongService>(uow => new SongService(uow));
            AddToCreationMethods<ISongStyleService>(uow => new SongStyleService(uow));
            AddToCreationMethods<IStyleService>(uow => new StyleService(uow));
            AddToCreationMethods<ITabService>(uow => new TabService(uow));
            AddToCreationMethods<ITuningNoteService>(uow => new TuningNoteService(uow));
            AddToCreationMethods<IUserFolderService>(uow => new UserFolderService(uow));
            AddToCreationMethods<IUserInstrumentService>(uow => new UserInstrumentService(uow));
            AddToCreationMethods<IVideoService>(uow => new VideoService(uow));
        }

    }

}