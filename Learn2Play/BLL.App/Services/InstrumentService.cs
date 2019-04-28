using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class InstrumentService : BaseEntityService<BLL.App.DTO.DomainEntityDTOs.Instrument, DAL.App.DTO.DomainEntityDTOs.Instrument, IAppUnitOfWork>, IInstrumentService
    {
        public InstrumentService(IAppUnitOfWork uow) : base(uow, new InstrumentMapper())
        {
        }
    }
}