using RX.Gateway.Model.Core;
using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using RX.Gateway.Service.Interface;

namespace RX.Gateway.Service
{
    internal class ServiceOperationCollectionResult<T> : ServiceOperationBaseResult, IServiceOperationCollectionResult<T>
                                 where T : GatewayObject
    {
        public IReadOnlyCollection<T> Entities { get; internal set; }

      
    }

}
