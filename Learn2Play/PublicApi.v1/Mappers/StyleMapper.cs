using System;
using externalDTO = PublicApi.v1.DTO.DomainEntityDTOs;
using internalDTO = BLL.App.DTO.DomainEntityDTOs;


namespace PublicApi.v1.Mappers
{
    public class StyleMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Style))
            {
                return MapFromBLL((internalDTO.Style) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Style))
            {
                return MapFromExternal((externalDTO.Style) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Style MapFromBLL(internalDTO.Style style)
        {
            var res = style == null ? null : new externalDTO.Style
            {
                Id = style.Id,
                Name = style.Name,
                Description = style.Description           
            };


            return res;
        }

        public static internalDTO.Style MapFromExternal(externalDTO.Style style)
        {
            var res = style == null ? null : new internalDTO.Style
            {
                Id = style.Id,
                Name = style.Name,
                Description = style.Description
            };

            return res;
        }

    }
}