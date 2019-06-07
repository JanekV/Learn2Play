using System.Collections.Generic;
using BLL.App.DTO.DomainEntityDTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BLL.App.DTO
{
    public class SongWithEverything
    {
        public int Id { get; set; } // Set to SongId so no need for another field!
        public string SongName { get; set; }
        public string SongAuthor { get; set; }
        public string SpotifyLink { get; set; }
        public string SongDescription { get; set; }
        
        public int SongKeyId { get; set; }
        public string SongKeyNoteName { get; set; }
        public string SongKeyDescription { get; set; }

        public SelectList SongKeySelectList { get; set; }
        
        public int FoldersCount { get; set; }

        public SelectList InstrumentSelectList { get; set; }
        public MultiSelectList InstrumentMultiSelectList { get; set; }
        public List<Instrument> Instruments { get; set; }

        public SelectList StyleSelectList { get; set; }
        public MultiSelectList StyleMultiSelectList { get; set; }
        public List<Style> Styles { get; set; }
        public List<int> StyleIds { get; set; }
        
        public SelectList ChordSelectList { get; set; }
        public MultiSelectList ChordMultiSelectList { get; set; }
        public List<Chord> Chords { get; set; }

        public SelectList VideoSelectList { get; set; }
        public MultiSelectList VideoMultiSelectList { get; set; }
        public List<Video> Videos { get; set; }
    }
}