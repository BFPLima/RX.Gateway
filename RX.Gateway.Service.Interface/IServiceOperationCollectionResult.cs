using RX.Gateway.Model.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Service.Interface
{
    public interface IServiceOperationCollectionResult<T> : IServiceOperationBaseResult
                                 where T : GatewayObject
    {
        IReadOnlyCollection<T> Entities { get; }
    }

}
