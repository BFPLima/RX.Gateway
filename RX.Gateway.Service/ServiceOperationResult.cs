using RX.Gateway.Model.Core;
using RX.Gateway.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Service
{
    public class ServiceOperationResult<T> : ServiceOperationBaseResult, IServiceOperationResult<T>
                                 where T : GatewayObject

    {
        public T Entity { get; internal set; }
    }


}
