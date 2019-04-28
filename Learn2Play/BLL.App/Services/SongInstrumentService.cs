using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL.App.Services
{
    public class SongInstrumentService : BaseEntityService<BLL.App.DTO.DomainEntityDTOs.SongInstrument, DAL.App.DTO.DomainEntityDTOs.SongInstrument, IAppUnitOfWork>, ISongInstrumentService
    {
        public SongInstrumentService(IAppUnitOfWork uow) : base(uow, new SongInstrumentMapper())
        {
        }

        public async Task<List<BLL.App.DTO.DomainEntityDTOs.SongInstrument>> AllAsyncWithInclude()
        {
            return (await Uow.SongInstruments.AllAsyncWithInclude()).Select(SongInstrumentMapper.MapFromDAL).ToList();
        }
    }
}