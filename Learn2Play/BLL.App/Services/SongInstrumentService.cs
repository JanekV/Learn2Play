using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class SongInstrumentService : BaseEntityService<SongInstrument, IAppUnitOfWork>, ISongInstrumentService
    {
        public SongInstrumentService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<IEnumerable<SongInstrument>> AllAsyncWithInclude()
        {
            return await Uow.SongInstruments.AllAsyncWithInclude();
        }
    }
}