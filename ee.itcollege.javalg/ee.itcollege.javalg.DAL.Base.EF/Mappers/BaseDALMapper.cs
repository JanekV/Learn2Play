using System;
using AutoMapper;
using ee.itcollege.javalg.Contracts.DAL.Base;
using ee.itcollege.javalg.Contracts.DAL.Base.Mappers;

namespace ee.itcollege.javalg.DAL.Base.EF.Mappers
{
    public class BaseDALMapper<TDALEntity, TDomainEntity> : IBaseDALMapper
        where TDALEntity: class, new()
        where TDomainEntity: class, IDomainEntity, new()
    {
        //Automapper implementation for generic DTO maping, muy bad practice
        private readonly IMapper _mapper;

        public BaseDALMapper()
        {
            _mapper = new MapperConfiguration(config =>
                {
                    config.CreateMap<TDALEntity, TDomainEntity>();
                    config.CreateMap<TDomainEntity, TDALEntity>();
                }
            ).CreateMapper();
        }
        // Obsolete boolean -
        // true if the obsolete element usage generates a compiler error;
        // false if it generates a compiler warning.
        [Obsolete("Bad practice, avoid using! Opt for custom mappers designed for specific entities", false)]
        public TOutObject Map<TOutObject>(object inObject) where TOutObject : class
        {
            return _mapper.Map<TOutObject>(inObject);
        }

    }

}