using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL.App.Services
{
    public class UserInstrumentService : BaseEntityService<BLL.App.DTO.DomainEntityDTOs.UserInstrument, DAL.App.DTO.DomainEntityDTOs.UserInstrument, IAppUnitOfWork>, IUserInstrumentService
    {
        public UserInstrumentService(IAppUnitOfWork uow) : base(uow, new UserInstrumentMapper())
        {
            ServiceRepository = Uow.UserInstruments;
        }

        public async Task<List<BLL.App.DTO.DomainEntityDTOs.UserInstrument>> AllAsyncWithInclude()
        {
            return (await Uow.UserInstruments.AllAsyncWithInclude()).Select(UserInstrumentMapper.MapFromDAL).ToList();
        }
    }
}