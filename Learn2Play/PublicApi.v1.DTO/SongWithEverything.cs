using System.Collections.Generic;
using PublicApi.v1.DTO.DomainEntityDTOs;

namespace PublicApi.v1.DTO
{
    public class SongWithEverything
    {
        public int Id { get; set; } // Set to SongId so no need for another field!
        public string Name { get; set; }
        public string Author { get; set; }
        public string SpotifyLink { get; set; }
        public string Description { get; set; }

        public string SongKeyDescription { get; set; }
        public string SongKeyNote { get; set; }
        
        public List<Instrument> Instruments { get; set; }
        public List<Style> Styles { get; set; }
        public List<Chord> Chords { get; set; }
        public List<Video> Videos { get; set; }
    }
}