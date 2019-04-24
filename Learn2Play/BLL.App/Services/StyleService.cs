using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;

namespace BLL.App.Services
{
    public class StyleService : BaseEntityService<Style, IAppUnitOfWork>, IStyleService
    {
        public StyleService(IAppUnitOfWork uow) : base(uow)
        {
        }

    }
}