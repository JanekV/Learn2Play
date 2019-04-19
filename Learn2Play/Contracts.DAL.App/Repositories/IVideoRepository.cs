using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface IVideoRepository : IBaseRepository<Video>
    {
        Task<IEnumerable<Video>> AllAsyncWithInclude();
    }
}