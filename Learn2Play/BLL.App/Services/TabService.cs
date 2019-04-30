using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL.App.Services
{
    public class TabService : BaseEntityService<BLL.App.DTO.DomainEntityDTOs.Tab, DAL.App.DTO.DomainEntityDTOs.Tab, IAppUnitOfWork>, ITabService
    {
        public TabService(IAppUnitOfWork uow) : base(uow, new TabMapper())
        {
            ServiceRepository = Uow.Tabs;
        }

        public async Task<List<BLL.App.DTO.DomainEntityDTOs.Tab>> AllAsyncWithInclude()
        {
            return (await Uow.Tabs.AllAsyncWithInclude()).Select(TabMapper.MapFromDAL).ToList();
        }
    }
}