using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface ISongInstrumentRepository: IBaseRepositoryAsync<SongInstrument>
    {
        Task<IEnumerable<SongInstrument>> AllAsyncWithInclude();
    }
}