using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface ISongInFolderRepository: IBaseRepositoryAsync<SongInFolder>
    {
        Task<IEnumerable<SongInFolder>> AllAsyncWithInclude();
    }
}