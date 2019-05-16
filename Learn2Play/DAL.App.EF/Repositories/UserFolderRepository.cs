using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.javalg.DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class UserFolderRepository: BaseRepository<DAL.App.DTO.DomainEntityDTOs.UserFolder, Domain.UserFolder, AppDbContext>, IUserFolderRepository
    {
        public UserFolderRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new UserFolderMapper())
        {
        }

        public async Task<List<DAL.App.DTO.DomainEntityDTOs.UserFolder>> AllAsyncWithInclude()
        {
            return await RepositoryDbSet
                .Include(uf => uf.AppUser)
                .Include(uf => uf.Folder)
                .Select(e => UserFolderMapper.MapFromDomain(e))
                .ToListAsync();
        }
        
        public async Task<DAL.App.DTO.DomainEntityDTOs.UserFolder> FindAsync(int id)
        {
            /*var userFolder = await base.FindAsync(id);
            if (userFolder != null)
            {
                await RepositoryDbContext.Entry(userFolder)
                    .Reference(uf => uf.AppUser).LoadAsync();
                await RepositoryDbContext.Entry(userFolder)
                    .Reference(uf => uf.Folder).LoadAsync();
            }
            return userFolder;
            */

            var userFolder = await RepositoryDbSet
                .Include(uf => uf.AppUser)
                .Include(uf => uf.Folder)
                .FirstOrDefaultAsync(uf => uf.Id == id);
            
            
            return UserFolderMapper.MapFromDomain(userFolder);
        }
    }
}