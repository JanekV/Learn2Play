using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using ee.itcollege.javalg.BLL.Base.Services;

namespace BLL.App.Services
{
    public class SongService : BaseEntityService<BLL.App.DTO.DomainEntityDTOs.Song, DAL.App.DTO.DomainEntityDTOs.Song, IAppUnitOfWork>, ISongService
    {
        public SongService(IAppUnitOfWork uow) : base(uow, new SongMapper())
        {
            ServiceRepository = Uow.Songs;
        }

        public async Task<List<BLL.App.DTO.DomainEntityDTOs.Song>> AllAsyncWithInclude()
        {
            return (await Uow.Songs.AllAsyncWithInclude()).Select(SongMapper.MapFromDAL).ToList();
        }
    }
}