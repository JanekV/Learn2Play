using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class FolderRepository: BaseRepository<Folder, AppDbContext>, IFolderRepository
    {
        public FolderRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }

    }
}