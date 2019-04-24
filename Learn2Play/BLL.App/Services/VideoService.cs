using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class VideoService : BaseEntityService<Video, IAppUnitOfWork>, IVideoService
    {
        public VideoService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<IEnumerable<Video>> AllAsyncWithInclude()
        {
            return await Uow.Videos.AllAsyncWithInclude();
        }
    }
}