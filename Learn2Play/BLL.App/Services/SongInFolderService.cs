using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class SongInFolderService : BaseEntityService<SongInFolder, IAppUnitOfWork>, ISongInFolderService
    {
        public SongInFolderService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<IEnumerable<SongInFolder>> AllAsyncWithInclude()
        {
            return await Uow.SongInFolders.AllAsyncWithInclude();
        }
    }
}