using Contracts.BLL.App.Services;
using Contrtacts.BLL.Base;

namespace Contracts.BLL.App
{
    public interface IAppBLL: IBaseBLL
    {
        IChordService Chords { get; }
        IChordNoteService ChordNotes { get; }
        IFolderService Folders { get; }
        IUserFolderService UserFolders { get; }
        IUserInstrumentService UserInstruments { get; }
        IInstrumentService Instruments { get; }
        INoteService Notes { get; }
        ISongService Songs { get; }
        ISongKeyService SongKeys { get; }
        ISongChordService SongChords { get; }
        ISongStyleService SongStyles { get; }
        ISongInstrumentService SongInstruments { get; }
        ISongInFolderService SongInFolders { get; }
        ITabService Tabs { get; }
        ITuningNoteService TuningNotes { get; }
        IVideoService Videos { get; }
        IStyleService Styles { get; }
        IAppUserService AppUsers { get; }
    }
}