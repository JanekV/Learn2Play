using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class ChordNoteService : BaseEntityService<ChordNote, IAppUnitOfWork>, IChordNoteService
    {
        public ChordNoteService(IAppUnitOfWork uow) : base(uow)
        {
        }
        public Task<List<ChordNote>> AllAsyncWithInclude()
        {
            return Uow.ChordNotes.AllAsyncWithInclude();
        }
    }
}