using System.Collections.Generic;
using DAL.App.DTO.DomainEntityDTOs;

namespace DAL.App.DTO
{
    public class SongWithEverything
    {
        public int Id { get; set; } // Set to SongId so no need for another field!
        public string SongName { get; set; }
        public string SongAuthor { get; set; }
        public string SpotifyLink { get; set; }
        public string SongDescription { get; set; }
        
        public SongKey SongKey { get; set; }
        public string SongKeyNoteName { get; set; } // Get Note.Name of the SongKey
        public string SongKeyDescription { get; set; }

        // public List<Folder> Folders { get; set; }
        public int FoldersCount { get; set; }
        public List<Instrument> Instruments { get; set; }
        public List<int> StyleIds { get; set; }
        public List<Chord> Chords { get; set; } // Get notes also?
        public List<Video> Videos { get; set; }
        public List<Tab> Tabs { get; set; }
        public List<int> InstrumentIds { get; set; }
        public int SongKeyId { get; set; }
    }
}