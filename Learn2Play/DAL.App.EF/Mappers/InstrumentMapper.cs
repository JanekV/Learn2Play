using System;
using ee.itcollege.javalg.Contracts.DAL.Base.Mappers;
using DALAppDTO = DAL.App.DTO;


namespace DAL.App.EF.Mappers
{
    public class InstrumentMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DALAppDTO.DomainEntityDTOs.Instrument))
            {
                return MapFromDomain((Domain.Instrument) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.Instrument))
            {
                return MapFromDAL((DALAppDTO.DomainEntityDTOs.Instrument) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static DALAppDTO.DomainEntityDTOs.Instrument MapFromDomain(Domain.Instrument instrument)
        {
            var res = instrument == null ? null : new DALAppDTO.DomainEntityDTOs.Instrument
            {
                Id = instrument.Id,
                Name = instrument.Name,                
                Description = instrument.Description              
            };


            return res;
        }

        public static Domain.Instrument MapFromDAL(DALAppDTO.DomainEntityDTOs.Instrument instrument)
        {
            var res = instrument == null ? null : new Domain.Instrument
            {
                Id = instrument.Id,
                Name = instrument.Name,
                Description = instrument.Description
            };

            return res;
        }

    }
}