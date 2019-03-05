using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class FolderRepository: BaseRepository<Folder>, IFolderRepository
    {
        public FolderRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}