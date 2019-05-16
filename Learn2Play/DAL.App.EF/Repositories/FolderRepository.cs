using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.javalg.DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class FolderRepository: BaseRepository<DAL.App.DTO.DomainEntityDTOs.Folder, Domain.Folder, AppDbContext>, IFolderRepository
    {
        public FolderRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new FolderMapper())
        {
        }

    }
}