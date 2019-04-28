namespace BLL.App.DTO.DomainEntityDTOs
{
    public class SongInstrument
    {
        public int Id { get; set; }

        public int SongId { get; set; }
        public Song Song { get; set; }

        public int InstrumentId { get; set; }
        public Instrument Instrument { get; set; }
    }
}