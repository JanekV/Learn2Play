using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class StyleRepository: BaseRepository<DAL.App.DTO.DomainEntityDTOs.Style, Domain.Style, AppDbContext>, IStyleRepository
    {
        public StyleRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new StyleMapper())
        {
        }
    }
}