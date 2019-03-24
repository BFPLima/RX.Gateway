using RX.Gateway.Model.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Service.Interface
{
    public interface IServiceOperationResult<T> : IServiceOperationBaseResult
                 where T : GatewayObject
    {
        T Entity { get; }
    }


}
