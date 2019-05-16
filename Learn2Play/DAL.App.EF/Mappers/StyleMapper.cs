using System;
using ee.itcollege.javalg.Contracts.DAL.Base.Mappers;
using Domain;
using DALAppDTO = DAL.App.DTO;


namespace DAL.App.EF.Mappers
{
    public class StyleMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DALAppDTO.DomainEntityDTOs.Style))
            {
                return MapFromDomain((Domain.Style) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.Style))
            {
                return MapFromDAL((DALAppDTO.DomainEntityDTOs.Style) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static DALAppDTO.DomainEntityDTOs.Style MapFromDomain(Domain.Style style)
        {
            var res = style == null ? null : new DALAppDTO.DomainEntityDTOs.Style
            {
                Id = style.Id,
                Name = style.Name.Translate(),
                Description = style.Description   
            };


            return res;
        }

        public static Domain.Style MapFromDAL(DALAppDTO.DomainEntityDTOs.Style style)
        {
            var res = style == null ? null : new Domain.Style
            {
                Id = style.Id,
                Name = new Domain.MultiLangString(style.Name),
                Description = style.Description   
            };

            return res;
        }

    }
}