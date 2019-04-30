using BLL.Base;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using Contracts.BLL.Base.Helpers;
using Contracts.DAL.App;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.App
{
    public class AppBLL : BaseBLL<IAppUnitOfWork>, IAppBLL
    {
        protected readonly IAppUnitOfWork AppUnitOfWork;
        
        public AppBLL(IAppUnitOfWork appUnitOfWork, IBaseServiceProvider serviceProvider) : base(appUnitOfWork, serviceProvider)
        {
            AppUnitOfWork = appUnitOfWork;
        }

        /*public IAppUserService AppUsers =>
            ServiceProvider.GetService<IAppUserService>();*/
        public IChordService Chords =>
            ServiceProvider.GetService<IChordService>();
        public IChordNoteService ChordNotes =>
            ServiceProvider.GetService<IChordNoteService>();
        public IFolderService Folders =>
            ServiceProvider.GetService<IFolderService>();
        public IInstrumentService Instruments =>
            ServiceProvider.GetService<IInstrumentService>();
        public INoteService Notes =>
            ServiceProvider.GetService<INoteService>();
        public ISongService Songs =>
            ServiceProvider.GetService<ISongService>();
        public ISongChordService SongChords =>
            ServiceProvider.GetService<ISongChordService>();
        public ISongInFolderService SongInFolders =>
            ServiceProvider.GetService<ISongInFolderService>();
        public ISongInstrumentService SongInstruments =>
            ServiceProvider.GetService<ISongInstrumentService>();
        public ISongKeyService SongKeys =>
            ServiceProvider.GetService<ISongKeyService>();
        public ISongStyleService SongStyles =>
            ServiceProvider.GetService<ISongStyleService>();
        public IStyleService Styles =>
            ServiceProvider.GetService<IStyleService>();

        public ITabService Tabs =>
            ServiceProvider.GetService<ITabService>();
        public ITuningNoteService TuningNotes =>
            ServiceProvider.GetService<ITuningNoteService>();
        public IUserFolderService UserFolders =>
            ServiceProvider.GetService<IUserFolderService>();
        public IUserInstrumentService UserInstruments =>
            ServiceProvider.GetService<IUserInstrumentService>();
        public IVideoService Videos =>
            ServiceProvider.GetService<IVideoService>();
        
    }

}