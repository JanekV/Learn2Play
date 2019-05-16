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
    public class TuningNoteRepository: BaseRepository<DAL.App.DTO.DomainEntityDTOs.TuningNote, Domain.TuningNote, AppDbContext>, ITuningNoteRepository
    {
        public TuningNoteRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new TuningNoteMapper())
        {
        }

        public async Task<List<DAL.App.DTO.DomainEntityDTOs.TuningNote>> AllAsyncWithInclude()
        {
            return await RepositoryDbSet
                .Include(tn => tn.Instrument)
                .Include(tn => tn.Note)
                .Select(e => TuningNoteMapper.MapFromDomain(e))
                .ToListAsync();
        }
        
        public async Task<DAL.App.DTO.DomainEntityDTOs.TuningNote> FindAsync(int id)
        {
            /*var tuningNote = await base.FindAsync(id);
            if (tuningNote != null)
            {
                await RepositoryDbContext.Entry(tuningNote)
                    .Reference(tn => tn.Instrument).LoadAsync();
                await RepositoryDbContext.Entry(tuningNote)
                    .Reference(tn => tn.Note).LoadAsync();
            }
            return tuningNote;
            */

            var tuningNote = await RepositoryDbSet
                .Include(tn => tn.Instrument)
                .Include(tn => tn.Note)
                .FirstOrDefaultAsync(tn => tn.Id == id);
            
            
            return TuningNoteMapper.MapFromDomain(tuningNote);
        }
    }
}