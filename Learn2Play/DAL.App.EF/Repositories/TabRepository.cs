using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class TabRepository: BaseRepository<Tab>, ITabRepository
    {
        public TabRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}