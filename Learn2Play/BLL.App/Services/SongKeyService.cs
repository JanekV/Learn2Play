using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL.App.Services
{
    public class SongKeyService : BaseEntityService<BLL.App.DTO.DomainEntityDTOs.SongKey, DAL.App.DTO.DomainEntityDTOs.SongKey, IAppUnitOfWork>, ISongKeyService
    {
        public SongKeyService(IAppUnitOfWork uow) : base(uow, new SongKeyMapper())
        {
        }

        public async Task<List<BLL.App.DTO.DomainEntityDTOs.SongKey>> AllAsyncWithInclude()
        {
            return (await Uow.SongKeys.AllAsyncWithInclude()).Select(SongKeyMapper.MapFromDAL).ToList();
        }
    }
}