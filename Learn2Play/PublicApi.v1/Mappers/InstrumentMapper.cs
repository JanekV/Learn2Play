using System;
using externalDTO = PublicApi.v1.DTO.DomainEntityDTOs;
using internalDTO = BLL.App.DTO.DomainEntityDTOs;

namespace PublicApi.v1.Mappers
{
    public class InstrumentMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Instrument))
            {
                return MapFromBLL((internalDTO.Instrument) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Instrument))
            {
                return MapFromExternal((externalDTO.Instrument) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Instrument MapFromBLL(internalDTO.Instrument instrument)
        {
            var res = instrument == null ? null : new externalDTO.Instrument
            {
                Id = instrument.Id,
                Name = instrument.Name,
                Description = instrument.Description
            };


            return res;
        }

        public static internalDTO.Instrument MapFromExternal(externalDTO.Instrument instrument)
        {
            var res = instrument == null ? null : new internalDTO.Instrument
            {
                Id = instrument.Id,
                Name = instrument.Name,
                Description = instrument.Description
            };

            return res;
        }

    }
}