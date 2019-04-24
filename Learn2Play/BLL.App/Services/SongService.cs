using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class SongService : BaseEntityService<Song, IAppUnitOfWork>, ISongService
    {
        public SongService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<IEnumerable<Song>> AllAsyncWithInclude()
        {
            return await Uow.Songs.AllAsyncWithInclude();
        }
    }
}