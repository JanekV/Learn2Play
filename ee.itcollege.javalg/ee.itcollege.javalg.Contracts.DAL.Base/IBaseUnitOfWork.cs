﻿using System;
using System.Threading.Tasks;
using ee.itcollege.javalg.Contracts.DAL.Base.Repositories;

namespace ee.itcollege.javalg.Contracts.DAL.Base
{
    public interface IBaseUnitOfWork
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();

        IBaseRepository<TDALEntity> BaseRepository<TDALEntity, TDomainEntity>()
            where TDALEntity : class, new()
            where TDomainEntity : class, IDomainEntity, new();

    }
}