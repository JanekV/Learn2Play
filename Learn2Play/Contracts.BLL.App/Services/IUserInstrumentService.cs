using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using BLLAppDTO = BLL.App.DTO.DomainEntityDTOs;

namespace Contracts.BLL.App.Services
{
    public interface IUserInstrumentService : IBaseEntityService<BLLAppDTO.UserInstrument>, IUserInstrumentRepository<BLLAppDTO.UserInstrument>
    {
        
    }
}