using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface ISongKeyRepository: IBaseRepositoryAsync<SongKey>
    {
        Task<IEnumerable<SongKey>> AllAsyncWithInclude();
    }
}