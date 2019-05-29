using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.javalg.DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Style = DAL.App.DTO.DomainEntityDTOs.Style;

namespace DAL.App.EF.Repositories
{
    public class StyleRepository: BaseRepository<DAL.App.DTO.DomainEntityDTOs.Style, Domain.Style, AppDbContext>, IStyleRepository
    {
        public StyleRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new StyleMapper())
        {
        }

        public override async Task<List<DAL.App.DTO.DomainEntityDTOs.Style>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(style => style.Name)
                .ThenInclude(s => s.Translations) 
                .Select(e => StyleMapper.MapFromDomain(e))
                .ToListAsync();
        }

        public override async Task<DAL.App.DTO.DomainEntityDTOs.Style> FindAsync(params object[] id)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            var style = await RepositoryDbSet.FindAsync(id);
            if (style != null)
            {
                await RepositoryDbContext.Entry(style).Reference(s => s.Name).LoadAsync();
                await RepositoryDbContext.Entry(style.Name).Collection(m => m.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
            }
            return StyleMapper.MapFromDomain(style);
        }

        public override DAL.App.DTO.DomainEntityDTOs.Style Update(Style entity)
        {
            var entityInDb = RepositoryDbSet
                .Include(s => s.Name)
                .ThenInclude(m => m.Translations)
                .FirstOrDefault(x => x.Id == entity.Id);

            entityInDb?.Name.SetTranslation(entity.Name);
            
            return entity;
        }
    }
}