using System.Linq;
using Contracts.DAL.Base;
using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF
{
    public class AppDbContext: IdentityDbContext<AppUser, AppRole, int>, IDataContext
    {
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<Tab> Tabs { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Chord> Chords { get; set; }

        public DbSet<ChordNote> ChordNotes { get; set; }
        public DbSet<SongChord> SongChords { get; set; }
        public DbSet<SongInFolder> SongInFolders { get; set; }
        public DbSet<SongInstrument> SongInstruments { get; set; }
        public DbSet<SongKey> SongKeys { get; set; }
        public DbSet<SongStyle> SongStyles { get; set; }
        public DbSet<TuningNote> TuningNotes { get; set; }
        public DbSet<UserFolder> UserFolders { get; set; }
        public DbSet<UserInstrument> UserInstruments { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // disable cascade delete
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }


    }
}