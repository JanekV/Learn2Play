using System;
using ee.itcollege.javalg.Contracts.BLL.Base.Mappers;


namespace BLL.App.Mappers
{
    public class InstrumentMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.DomainEntityDTOs.Instrument))
            {
                return MapFromDAL((DAL.App.DTO.DomainEntityDTOs.Instrument) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.DomainEntityDTOs.Instrument))
            {
                return MapFromBLL((BLL.App.DTO.DomainEntityDTOs.Instrument) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.DomainEntityDTOs.Instrument MapFromDAL(DAL.App.DTO.DomainEntityDTOs.Instrument instrument)
        {
            var res = instrument == null ? null : new BLL.App.DTO.DomainEntityDTOs.Instrument
            {
                Id = instrument.Id,
                Name = instrument.Name,
                Description = instrument.Description
            };


            return res;
        }

        public static DAL.App.DTO.DomainEntityDTOs.Instrument MapFromBLL(BLL.App.DTO.DomainEntityDTOs.Instrument instrument)
        {
            var res = instrument == null ? null : new DAL.App.DTO.DomainEntityDTOs.Instrument
            {
                Id = instrument.Id,
                Name = instrument.Name,
                Description = instrument.Description
            };

            return res;
        }

    }
}