using System;
using externalDTO = PublicApi.v1.DTO.DomainEntityDTOs;
using internalDTO = BLL.App.DTO.DomainEntityDTOs;


namespace PublicApi.v1.Mappers
{
    public class SongInstrumentMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.SongInstrument))
            {
                return MapFromBLL((internalDTO.SongInstrument) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.SongInstrument))
            {
                return MapFromExternal((externalDTO.SongInstrument) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.SongInstrument MapFromBLL(internalDTO.SongInstrument songInstrument)
        {
            var res = songInstrument == null ? null : new externalDTO.SongInstrument
            {
                Id = songInstrument.Id,
                SongId = songInstrument.SongId,
                Song = SongMapper.MapFromBLL(songInstrument.Song),
                InstrumentId = songInstrument.InstrumentId,
                Instrument = InstrumentMapper.MapFromBLL(songInstrument.Instrument)                
            };


            return res;
        }

        public static internalDTO.SongInstrument MapFromExternal(externalDTO.SongInstrument songInstrument)
        {
            var res = songInstrument == null ? null : new internalDTO.SongInstrument
            {
                Id = songInstrument.Id,
                SongId = songInstrument.SongId,
                Song = SongMapper.MapFromExternal(songInstrument.Song),
                InstrumentId = songInstrument.InstrumentId,
                Instrument = InstrumentMapper.MapFromExternal(songInstrument.Instrument) 
            };

            return res;
        }

    }
}