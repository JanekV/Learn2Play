namespace Domain
{
    public class SongInstrument
    {
        public int SongInstrumentId { get; set; }

        public int SongId { get; set; }
        public Song Song { get; set; }

        public int InstrumentId { get; set; }
        public Instrument Instrument { get; set; }
    }
}