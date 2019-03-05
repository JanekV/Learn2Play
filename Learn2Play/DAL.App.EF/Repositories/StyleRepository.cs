using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class StyleRepository: BaseRepository<Style>, IStyleRepository
    {
        public StyleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}