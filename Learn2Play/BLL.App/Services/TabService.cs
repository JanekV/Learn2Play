using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class TabService : BaseEntityService<Tab, IAppUnitOfWork>, ITabService
    {
        public TabService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<IEnumerable<Tab>> AllAsyncWithInclude()
        {
            return await Uow.Tabs.AllAsyncWithInclude();
        }
    }
}