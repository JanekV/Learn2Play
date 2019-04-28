using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL.App.Services
{
    public class VideoService : BaseEntityService<BLL.App.DTO.DomainEntityDTOs.Video, DAL.App.DTO.DomainEntityDTOs.Video, IAppUnitOfWork>, IVideoService
    {
        public VideoService(IAppUnitOfWork uow) : base(uow, new VideoMapper())
        {
        }

        public async Task<List<BLL.App.DTO.DomainEntityDTOs.Video>> AllAsyncWithInclude()
        {
            return (await Uow.Videos.AllAsyncWithInclude()).Select(VideoMapper.MapFromDAL).ToList();
        }
    }
}