using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
namespace BLL.App.Services
{
    public class ChordService : BaseEntityService<BLL.App.DTO.DomainEntityDTOs.Chord, DAL.App.DTO.DomainEntityDTOs.Chord, IAppUnitOfWork>, IChordService
    {
        public ChordService(IAppUnitOfWork uow) : base(uow, new ChordMapper())
        {
            ServiceRepository = Uow.Chords;
        }
    }
}