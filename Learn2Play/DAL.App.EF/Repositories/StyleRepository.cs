using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class StyleRepository: BaseRepository<Style>, IStyleRepository
    {
        public StyleRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}