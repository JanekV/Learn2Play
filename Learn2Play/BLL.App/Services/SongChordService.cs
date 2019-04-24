using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class SongChordService : BaseEntityService<SongChord, IAppUnitOfWork>, ISongChordService
    {
        public SongChordService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<IEnumerable<SongChord>> AllAsyncWithInclude()
        {
            return await Uow.SongChords.AllAsyncWithInclude();
        }
    }
}