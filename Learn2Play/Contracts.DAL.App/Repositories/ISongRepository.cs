using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface ISongRepository : IBaseRepository<Song>
    {
        Task<IEnumerable<Song>> AllAsyncWithInclude();
    }
}