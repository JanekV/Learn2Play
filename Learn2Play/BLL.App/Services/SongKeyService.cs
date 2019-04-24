using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class SongKeyService : BaseEntityService<SongKey, IAppUnitOfWork>, ISongKeyService
    {
        public SongKeyService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<IEnumerable<SongKey>> AllAsyncWithInclude()
        {
            return await Uow.SongKeys.AllAsyncWithInclude();
        }
    }
}