using System;

namespace ee.itcollege.javalg.Contracts.Base
{
    public interface ITrackableInstance
    {
        Guid InstanceId { get; }
    }
}