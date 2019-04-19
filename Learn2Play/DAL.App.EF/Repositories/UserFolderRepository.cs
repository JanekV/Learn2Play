using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class UserFolderRepository: BaseRepository<UserFolder, AppDbContext>, IUserFolderRepository
    {
        public UserFolderRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }

        public async Task<IEnumerable<UserFolder>> AllAsyncWithInclude()
        {
            return await RepositoryDbSet
                .Include(uf => uf.AppUser)
                .Include(uf => uf.Folder)
                .ToListAsync();
        }
        
        public override async Task<UserFolder> FindAsync(params object[] id)
        {
            var userFolder = await base.FindAsync(id);
            if (userFolder != null)
            {
                await RepositoryDbContext.Entry(userFolder)
                    .Reference(uf => uf.AppUser).LoadAsync();
                await RepositoryDbContext.Entry(userFolder)
                    .Reference(uf => uf.Folder).LoadAsync();
            }
            return userFolder;
        }
    }
}