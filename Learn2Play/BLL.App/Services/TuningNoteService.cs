using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using ee.itcollege.javalg.BLL.Base.Services;

namespace BLL.App.Services
{
    public class TuningNoteService : BaseEntityService<BLL.App.DTO.DomainEntityDTOs.TuningNote, DAL.App.DTO.DomainEntityDTOs.TuningNote, IAppUnitOfWork>, ITuningNoteService
    {
        public TuningNoteService(IAppUnitOfWork uow) : base(uow, new TuningNoteMapper())
        {
            ServiceRepository = Uow.TuningNotes;
        }

        public async Task<List<BLL.App.DTO.DomainEntityDTOs.TuningNote>> AllAsyncWithInclude()
        {
            return (await Uow.TuningNotes.AllAsyncWithInclude()).Select(TuningNoteMapper.MapFromDAL).ToList();
        }
    }
}