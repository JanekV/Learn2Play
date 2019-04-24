using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class ChordService : BaseEntityService<Chord, IAppUnitOfWork>, IChordService
    {
        public ChordService(IAppUnitOfWork uow) : base(uow)
        {
        }
    }
}