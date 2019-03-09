namespace Domain
{
    public class SongInstrument: BaseEntity
    {

        public int SongId { get; set; }
        public Song Song { get; set; }

        public int InstrumentId { get; set; }
        public Instrument Instrument { get; set; }
    }
}