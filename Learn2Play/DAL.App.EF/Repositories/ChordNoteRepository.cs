using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO.DomainEntityDTOs;
using DAL.App.EF.Mappers;
using ee.itcollege.javalg.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;
namespace DAL.App.EF.Repositories
{
    public class ChordNoteRepository: BaseRepository<DAL.App.DTO.DomainEntityDTOs.ChordNote, Domain.ChordNote, AppDbContext>, IChordNoteRepository
    {
        public ChordNoteRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new ChordNoteMapper())
        {
        }

        public async Task<List<DAL.App.DTO.DomainEntityDTOs.ChordNote>> AllAsyncWithInclude()
        {
            return await RepositoryDbSet
                .Include(cn => cn.Chord)
                .Include(cn => cn.Note)
                .Select(e => ChordNoteMapper.MapFromDomain(e))
                .ToListAsync();
        }
        
        public async Task<DAL.App.DTO.DomainEntityDTOs.ChordNote> FindAsync(int id)
        {
            var chordNote = await RepositoryDbSet
                .Include(cn => cn.Chord)
                .Include(cn => cn.Note)
                .FirstOrDefaultAsync(cn => cn.Id == id);
            
            
            return ChordNoteMapper.MapFromDomain(chordNote);
        }
    }
}