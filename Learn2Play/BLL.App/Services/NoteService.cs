using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class NoteService : BaseEntityService<Note, IAppUnitOfWork>, INoteService
    {
        public NoteService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}