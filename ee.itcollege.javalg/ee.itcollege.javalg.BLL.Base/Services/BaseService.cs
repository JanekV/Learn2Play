using System;
using ee.itcollege.javalg.Contracts.BLL.Base.Services;

namespace ee.itcollege.javalg.BLL.Base.Services
{
    public class BaseService : IBaseService
    {
        private readonly Guid _instanceId = Guid.NewGuid();
        public Guid InstanceId => _instanceId;
    }

}