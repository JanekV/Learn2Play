using System;
using externalDTO = PublicApi.v1.DTO.DomainEntityDTOs;
using internalDTO = BLL.App.DTO.DomainEntityDTOs;

namespace PublicApi.v1.Mappers
{
    public class FolderMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Folder))
            {
                return MapFromBLL((internalDTO.Folder) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Folder))
            {
                return MapFromExternal((externalDTO.Folder) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Folder MapFromBLL(internalDTO.Folder folder)
        {
            var res = folder == null ? null : new externalDTO.Folder
            {
                Id = folder.Id,
                Name = folder.Name,
                FolderType = folder.FolderType,
                Comment = folder.Comment
                
            };


            return res;
        }

        public static internalDTO.Folder MapFromExternal(externalDTO.Folder folder)
        {
            var res = folder == null ? null : new internalDTO.Folder
            {
                Id = folder.Id,
                Name = folder.Name,
                FolderType = folder.FolderType,
                Comment = folder.Comment
            };

            return res;
        }

    }
}