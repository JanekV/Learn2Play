using ee.itcollege.javalg.Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using BLLAppDTO = BLL.App.DTO.DomainEntityDTOs;

namespace Contracts.BLL.App.Services
{
    public interface ITuningNoteService : IBaseEntityService<BLLAppDTO.TuningNote>, ITuningNoteRepository<BLLAppDTO.TuningNote>
    {
        
    }
}