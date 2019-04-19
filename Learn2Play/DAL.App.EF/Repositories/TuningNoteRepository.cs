using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class TuningNoteRepository: BaseRepository<TuningNote, AppDbContext>, ITuningNoteRepository
    {
        public TuningNoteRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }

        public async Task<IEnumerable<TuningNote>> AllAsyncWithInclude()
        {
            return await RepositoryDbSet
                .Include(tn => tn.Instrument)
                .Include(tn => tn.Note)
                .ToListAsync();
        }
        
        public override async Task<TuningNote> FindAsync(params object[] id)
        {
            var tuningNote = await base.FindAsync(id);
            if (tuningNote != null)
            {
                await RepositoryDbContext.Entry(tuningNote)
                    .Reference(tn => tn.Instrument).LoadAsync();
                await RepositoryDbContext.Entry(tuningNote)
                    .Reference(tn => tn.Note).LoadAsync();
            }
            return tuningNote;
        }
    }
}