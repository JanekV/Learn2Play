using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO.DomainEntityDTOs;
using BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using ee.itcollege.javalg.BLL.Base.Services;

namespace BLL.App.Services
{
    public class SongStyleService : BaseEntityService<BLL.App.DTO.DomainEntityDTOs.SongStyle, DAL.App.DTO.DomainEntityDTOs.SongStyle, IAppUnitOfWork>, ISongStyleService
    {
        public SongStyleService(IAppUnitOfWork uow) : base(uow, new SongStyleMapper())
        {
            ServiceRepository = Uow.SongStyles;
        }

        public async Task<List<BLL.App.DTO.DomainEntityDTOs.SongStyle>> AllAsyncWithInclude()
        {
            return (await Uow.SongStyles.AllAsyncWithInclude()).Select(SongStyleMapper.MapFromDAL).ToList();
        }

        public async Task<SongStyle> FindByStyleAndSongIdAsync(int styleId, int songId)
        {
            return SongStyleMapper.MapFromDAL(await Uow.SongStyles.FindByStyleAndSongIdAsync(styleId, songId));
        }
    }
}