using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO.DomainEntityDTOs;
using BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using ee.itcollege.javalg.BLL.Base.Services;

namespace BLL.App.Services
{
    public class StyleService : BaseEntityService<BLL.App.DTO.DomainEntityDTOs.Style, DAL.App.DTO.DomainEntityDTOs.Style
        , IAppUnitOfWork>, IStyleService
    {
        public StyleService(IAppUnitOfWork uow) : base(uow, new StyleMapper())
        {
            ServiceRepository = Uow.Styles;
        }
    }
}