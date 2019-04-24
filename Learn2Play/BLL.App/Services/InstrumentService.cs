using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class InstrumentService : BaseEntityService<Instrument, IAppUnitOfWork>, IInstrumentService
    {
        public InstrumentService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}