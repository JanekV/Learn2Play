﻿using System;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;

namespace Contracts.DAL.App
{
    public interface IAppUnitOfWork : IUnitOfWork
    {
        IChordRepository Chords { get; }
        IChordNoteRepository ChordNotes { get; }
        IFolderRepository Folders { get; }
        IUserFolderRepository UserFolders { get; }
        IUserInstrumentRepository UserInstruments { get; }
        IInstrumentRepository Instruments { get; }
        INoteRepository Notes { get; }
        ISongRepository Songs { get; }
        ISongKeyRepository SongKeys { get; }
        ISongChordRepository SongChords { get; }
        ISongStyleRepository SongStyles { get; }
        ISongInstrumentRepository SongInstruments { get; }
        ISongInFolderRepository SongInFolders { get; }
        ITabRepository Tabs { get; }
        ITuningNoteRepository TuningNotes { get; }
        IVideoRepository Videos { get; }
        IStyleRepository Styles { get; }
        IAppUserRepository AppUser { get; set; }
    }
}