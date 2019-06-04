using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.javalg.DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Note = DAL.App.DTO.DomainEntityDTOs.Note;

namespace DAL.App.EF.Repositories
{
    public class NoteRepository: BaseRepository<DAL.App.DTO.DomainEntityDTOs.Note, Domain.Note, AppDbContext>, INoteRepository
    {
        public NoteRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new NoteMapper())
        {
        }

        public override async Task<Note> AddAsync(Note note)
        {
            if (!(await RepositoryDbSet.AnyAsync(n => n.Name.Equals(note.Name))))
            {
                 return await base.AddAsync(note);
            }
            return null;
        }

        public async Task AddMultipleAsync(List<Note> notes)
        {
            foreach (var note in notes)
            {
                await AddAsync(note);
            }
        }
    }
}