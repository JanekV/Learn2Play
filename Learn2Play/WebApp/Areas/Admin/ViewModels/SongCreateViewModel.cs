using System.Collections.Generic;
using BLL.App.DTO.DomainEntityDTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using Song = BLL.App.DTO.DomainEntityDTOs.Song;

namespace WebApp.Areas.Admin.ViewModels
{
    public class SongCreateViewModel
    {
        //Creating Song
        public Song Song { get; set; }
        public SelectList SongKeySelectList { get; set; }
        
        //Adding Style(s)
        public Style Style { get; set; }
        public SelectList StylesSelectList { get; set; }
        public List<Style> Styles { get; set; }
        
        //Adding Chord(s)
        public Chord Chord { get; set; }
        public SelectList ChordSelectList { get; set; }
        public List<Chord> Chords { get; set; }
        
        //Adding Instrument(s)
        public Instrument Instrument { get; set; }
        public SelectList InstrumentSelectList { get; set; }
        public List<Instrument> Instruments { get; set; }
        
        //Adding Video(s) and Tab(s) to them
        public Video Video { get; set; }
        public List<Video> Videos { get; set; }

        public Tab Tab { get; set; }
        public List<Tab> Tabs { get; set; }
    }
}