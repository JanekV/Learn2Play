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
        
        public SongKey SongKey { get; set; }
        public string SongKeyNoteName { get; set; }
        public string SongKeyDescription { get; set; }

        public int FoldersCount { get; set; }
        
        public List<Instrument> Instruments { get; set; }
        
        public List<Style> Styles { get; set; }
        public List<int> StyleIds { get; set; }
        public List<Chord> Chords { get; set; }
        
        public List<Video> Videos { get; set; }
    }
}