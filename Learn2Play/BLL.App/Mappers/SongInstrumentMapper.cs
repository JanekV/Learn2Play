using System;
using ee.itcollege.javalg.Contracts.BLL.Base.Mappers;


namespace BLL.App.Mappers
{
    public class SongInstrumentMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.DomainEntityDTOs.SongInstrument))
            {
                return MapFromDAL((DAL.App.DTO.DomainEntityDTOs.SongInstrument) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.DomainEntityDTOs.SongInstrument))
            {
                return MapFromBLL((BLL.App.DTO.DomainEntityDTOs.SongInstrument) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.DomainEntityDTOs.SongInstrument MapFromDAL(DAL.App.DTO.DomainEntityDTOs.SongInstrument songInstrument)
        {
            var res = songInstrument == null ? null : new BLL.App.DTO.DomainEntityDTOs.SongInstrument
            {
                Id = songInstrument.Id,
                SongId = songInstrument.SongId,
                Song = SongMapper.MapFromDAL(songInstrument.Song),
                InstrumentId = songInstrument.InstrumentId,
                Instrument = InstrumentMapper.MapFromDAL(songInstrument.Instrument)                
            };


            return res;
        }

        public static DAL.App.DTO.DomainEntityDTOs.SongInstrument MapFromBLL(BLL.App.DTO.DomainEntityDTOs.SongInstrument songInstrument)
        {
            var res = songInstrument == null ? null : new DAL.App.DTO.DomainEntityDTOs.SongInstrument
            {
                Id = songInstrument.Id,
                SongId = songInstrument.SongId,
                Song = SongMapper.MapFromBLL(songInstrument.Song),
                InstrumentId = songInstrument.InstrumentId,
                Instrument = InstrumentMapper.MapFromBLL(songInstrument.Instrument) 
            };

            return res;
        }

    }
}