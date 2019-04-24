using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class UserInstrumentService : BaseEntityService<UserInstrument, IAppUnitOfWork>, IUserInstrumentService
    {
        public UserInstrumentService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<IEnumerable<UserInstrument>> AllAsyncWithInclude()
        {
            return await Uow.UserInstruments.AllAsyncWithInclude();
        }
    }
}