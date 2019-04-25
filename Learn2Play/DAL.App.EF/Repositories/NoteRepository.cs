using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class NoteRepository: BaseRepository<DAL.App.DTO.DomainEntityDTOs.Note, Domain.Note, AppDbContext>, INoteRepository
    {
        public NoteRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new NoteMapper())
        {
        }
    }
}