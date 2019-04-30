using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL.App.Services
{
    public class StyleService : BaseEntityService<BLL.App.DTO.DomainEntityDTOs.Style, DAL.App.DTO.DomainEntityDTOs.Style, IAppUnitOfWork>, IStyleService
    {
        public StyleService(IAppUnitOfWork uow) : base(uow, new StyleMapper())
        {
            ServiceRepository = Uow.Styles;
        }
    }
}