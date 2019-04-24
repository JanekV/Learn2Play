using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class SongStyleService : BaseEntityService<SongStyle, IAppUnitOfWork>, ISongStyleService
    {
        public SongStyleService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<IEnumerable<SongStyle>> AllAsyncWithInclude()
        {
            return await Uow.SongStyles.AllAsyncWithInclude();
        }
    }
}