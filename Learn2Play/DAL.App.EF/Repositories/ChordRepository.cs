using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using ee.itcollege.javalg.DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Chord = DAL.App.DTO.DomainEntityDTOs.Chord;

namespace DAL.App.EF.Repositories
{
    public class ChordRepository: BaseRepository<DAL.App.DTO.DomainEntityDTOs.Chord, Domain.Chord, AppDbContext>, IChordRepository
    {
        public ChordRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new ChordMapper())
        {
        }
        
        /* Generated SQL:
         
            info: Microsoft.EntityFrameworkCore.Database.Command[20101]
            Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
            
            SELECT `c`.`Id`, `c`.`Name` AS `ChordName`, `c`.`ShapePicturePath`
            FROM `Chords` AS `c`
            
            info: Microsoft.EntityFrameworkCore.Database.Command[20101]
                Executed DbCommand (4ms) [Parameters=[@_outer_Id='?' (DbType = Int32), @_outer_Id1='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']
      
            SELECT `cn.Note`.`Id`, `cn.Note`.`Name`
            FROM `ChordNotes` AS `cn`
            INNER JOIN `Notes` AS `cn.Note` ON `cn`.`NoteId` = `cn.Note`.`Id`
            WHERE EXISTS (
                SELECT 1
                FROM `ChordNotes` AS `cn0`
                WHERE (`cn0`.`NoteId` = `cn`.`NoteId`) AND (@_outer_Id = `cn0`.`ChordId`)) AND (@_outer_Id1 = `cn`.`ChordId`)
        */
        /// <summary>
        /// Get all Chords with their Notes from db.
        /// </summary>
        /// <returns>List of DAL.App.DTO.ChordWithNotes elements.</returns>
        public virtual async Task<List<DAL.App.DTO.ChordWithNotes>> GetAllChordsWithNotesAsync()
        {
            var res = await RepositoryDbSet
                .Include(c => c.ChordNotes)
                .Select(c => new
                {
                    Id = c.Id,
                    ChordName = c.Name,
                    ShapePicturePath = c.ShapePicturePath,
                    Notes = c.ChordNotes
                        .Select(cn => cn.Note).ToList()
                })
                .ToListAsync();

            var resultList = res.Select(c => new DAL.App.DTO.ChordWithNotes()
            {
                Id = c.Id,
                ChordName = c.ChordName,
                ShapePicturePath = c.ShapePicturePath,
                Notes = c.Notes.ConvertAll(NoteMapper.MapFromDomain)
            }).ToList();

            return resultList;
        }

        public virtual async Task<DAL.App.DTO.ChordWithNotes> GetChordWithNotesAsync(int chordId)
        {
            var res = await RepositoryDbSet
                .Where(c => c.Id == chordId)
                .Include(c => c.ChordNotes)
                .Select(c => new
                {
                    Id = c.Id,
                    ChordName = c.Name,
                    ShapePicturePath = c.ShapePicturePath,
                    Notes = c.ChordNotes
                        .Select(cn => cn.Note).ToList()
                }).FirstOrDefaultAsync();
            var cwn = new DAL.App.DTO.ChordWithNotes()
            {
                Id = res.Id,
                ChordName = res.ChordName,
                ShapePicturePath = res.ShapePicturePath,
                Notes = res.Notes.ConvertAll(NoteMapper.MapFromDomain)
            };
            return cwn;
        }
        
        public async Task<Chord> FindDetachedAsync(int id)
        {
            var chordEntry = RepositoryDbContext.Entry(await RepositoryDbSet.FindAsync(id));
            if (chordEntry == null) return null;
            chordEntry.State = EntityState.Detached;
            var chord = chordEntry.Entity;
            return ChordMapper.MapFromDomain(chord);
        }
    }
}