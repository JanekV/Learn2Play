using BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using ee.itcollege.javalg.BLL.Base.Services;

namespace BLL.App.Services
{
    public class NoteService : BaseEntityService<BLL.App.DTO.DomainEntityDTOs.Note, DAL.App.DTO.DomainEntityDTOs.Note, IAppUnitOfWork>, INoteService
    {
        public NoteService(IAppUnitOfWork uow) : base(uow, new NoteMapper())
        {
            ServiceRepository = Uow.Notes;
        }
    }
}