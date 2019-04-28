using System;
using Contracts.DAL.Base.Mappers;
using DALAppDTO = DAL.App.DTO;


namespace DAL.App.EF.Mappers
{
    public class SongInstrumentMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DALAppDTO.DomainEntityDTOs.SongInstrument))
            {
                return MapFromDomain((Domain.SongInstrument) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.SongInstrument))
            {
                return MapFromDAL((DALAppDTO.DomainEntityDTOs.SongInstrument) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static DALAppDTO.DomainEntityDTOs.SongInstrument MapFromDomain(Domain.SongInstrument songInstrument)
        {
            var res = songInstrument == null ? null : new DALAppDTO.DomainEntityDTOs.SongInstrument
            {
                Id = songInstrument.Id,
                SongId = songInstrument.SongId,
                Song = SongMapper.MapFromDomain(songInstrument.Song),
                InstrumentId = songInstrument.InstrumentId,
                Instrument = InstrumentMapper.MapFromDomain(songInstrument.Instrument) 
            };


            return res;
        }

        public static Domain.SongInstrument MapFromDAL(DALAppDTO.DomainEntityDTOs.SongInstrument songInstrument)
        {
            var res = songInstrument == null ? null : new Domain.SongInstrument
            {
                Id = songInstrument.Id,
                SongId = songInstrument.SongId,
                Song = SongMapper.MapFromDAL(songInstrument.Song),
                InstrumentId = songInstrument.InstrumentId,
                Instrument = InstrumentMapper.MapFromDAL(songInstrument.Instrument) 
            };

            return res;
        }

    }
}