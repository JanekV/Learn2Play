using BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;
using ee.itcollege.javalg.BLL.Base.Services;

namespace BLL.App.Services
{
    public class InstrumentService : BaseEntityService<BLL.App.DTO.DomainEntityDTOs.Instrument, DAL.App.DTO.DomainEntityDTOs.Instrument, IAppUnitOfWork>, IInstrumentService
    {
        public InstrumentService(IAppUnitOfWork uow) : base(uow, new InstrumentMapper())
        {
            ServiceRepository = Uow.Instruments;
        }
    }
}