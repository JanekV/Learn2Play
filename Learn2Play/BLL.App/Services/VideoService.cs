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
    public class VideoService : BaseEntityService<BLL.App.DTO.DomainEntityDTOs.Video, DAL.App.DTO.DomainEntityDTOs.Video, IAppUnitOfWork>, IVideoService
    {
        public VideoService(IAppUnitOfWork uow) : base(uow, new VideoMapper())
        {
            ServiceRepository = Uow.Videos;
        }

        public async Task<List<BLL.App.DTO.DomainEntityDTOs.Video>> AllAsyncWithInclude()
        {
            return (await Uow.Videos.AllAsyncWithInclude()).Select(VideoMapper.MapFromDAL).ToList();
        }

        public async Task<Video> FindAsyncWithIncludeAsync(int id)
        {
            return VideoMapper.MapFromDAL(await Uow.Videos.FindAsyncWithIncludeAsync(id));
        }
    }
}