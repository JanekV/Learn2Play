using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface ISongStyleRepository: IBaseRepositoryAsync<SongStyle>
    {
        Task<IEnumerable<SongStyle>> AllAsyncWithInclude();
    }
}