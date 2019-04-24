using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class TuningNoteService : BaseEntityService<TuningNote, IAppUnitOfWork>, ITuningNoteService
    {
        public TuningNoteService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<IEnumerable<TuningNote>> AllAsyncWithInclude()
        {
            return await Uow.TuningNotes.AllAsyncWithInclude();
        }
    }
}