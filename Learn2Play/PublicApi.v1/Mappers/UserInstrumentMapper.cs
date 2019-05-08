using System;
using externalDTO = PublicApi.v1.DTO.DomainEntityDTOs;
using internalDTO = BLL.App.DTO.DomainEntityDTOs;


namespace PublicApi.v1.Mappers
{
    public class UserInstrumentMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.UserInstrument))
            {
                return MapFromBLL((internalDTO.UserInstrument) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.UserInstrument))
            {
                return MapFromExternal((externalDTO.UserInstrument) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.UserInstrument MapFromBLL(internalDTO.UserInstrument userInstrument)
        {
            var res = userInstrument == null ? null : new externalDTO.UserInstrument
            {
                Id = userInstrument.Id,
                AppUserId = userInstrument.AppUserId,
                InstrumentId = userInstrument.InstrumentId,
                Instrument = InstrumentMapper.MapFromBLL(userInstrument.Instrument),
                Comment = userInstrument.Comment  
                
            };


            return res;
        }

        public static internalDTO.UserInstrument MapFromExternal(externalDTO.UserInstrument userInstrument)
        {
            var res = userInstrument == null ? null : new internalDTO.UserInstrument
            {
                Id = userInstrument.Id,
                AppUserId = userInstrument.AppUserId,
                InstrumentId = userInstrument.InstrumentId,
                Instrument = InstrumentMapper.MapFromExternal(userInstrument.Instrument),
                Comment = userInstrument.Comment  
            };

            return res;
        }

    }
}