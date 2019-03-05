using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserFolderRepository: BaseRepository<UserFolder>, IUserFolderRepository
    {
        public UserFolderRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}