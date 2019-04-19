using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.App.EF;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ChordNoteRepository: BaseRepository<ChordNote, AppDbContext>, IChordNoteRepository
    {
        public ChordNoteRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }

        public async Task<IEnumerable<ChordNote>> AllAsyncWithInclude()
        {
            return await RepositoryDbSet
                .Include(cn => cn.Chord)
                .Include(cn => cn.Note)
                .ToListAsync();
        }
        
        public override async Task<ChordNote> FindAsync(params object[] id)
        {
            var chordNote = await base.FindAsync(id);
            if (chordNote != null)
            {
                await RepositoryDbContext.Entry(chordNote)
                    .Reference(cn => cn.Chord).LoadAsync();
                await RepositoryDbContext.Entry(chordNote)
                    .Reference(cn => cn.Chord).LoadAsync();
            }
            
            
            return chordNote;
        }
    }
}