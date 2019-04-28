using System;
using Contracts.DAL.Base.Mappers;
using DALAppDTO = DAL.App.DTO;


namespace DAL.App.EF.Mappers
{
    public class SongInFolderMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DALAppDTO.DomainEntityDTOs.SongInFolder))
            {
                return MapFromDomain((Domain.SongInFolder) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.SongInFolder))
            {
                return MapFromDAL((DALAppDTO.DomainEntityDTOs.SongInFolder) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static DALAppDTO.DomainEntityDTOs.SongInFolder MapFromDomain(Domain.SongInFolder songInFolder)
        {
            var res = songInFolder == null ? null : new DALAppDTO.DomainEntityDTOs.SongInFolder
            {
                Id = songInFolder.Id,
                FolderId = songInFolder.FolderId,
                Folder = FolderMapper.MapFromDomain(songInFolder.Folder),
                SongId = songInFolder.SongId,
                Song = SongMapper.MapFromDomain(songInFolder.Song) 
            };


            return res;
        }

        public static Domain.SongInFolder MapFromDAL(DALAppDTO.DomainEntityDTOs.SongInFolder songInFolder)
        {
            var res = songInFolder == null ? null : new Domain.SongInFolder
            {
                Id = songInFolder.Id,
                FolderId = songInFolder.FolderId,
                Folder = FolderMapper.MapFromDAL(songInFolder.Folder),
                SongId = songInFolder.SongId,
                Song = SongMapper.MapFromDAL(songInFolder.Song) 
            };

            return res;
        }

    }
}