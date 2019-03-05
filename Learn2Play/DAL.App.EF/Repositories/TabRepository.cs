using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class TabRepository: BaseRepository<Tab>, ITabRepository
    {
        public TabRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}