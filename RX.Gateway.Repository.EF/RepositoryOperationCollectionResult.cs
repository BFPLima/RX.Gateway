using RX.Gateway.Model.Core;
using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using RX.Gateway.Repository.Interface;

namespace RX.Gateway.Repository
{
    internal class RepositoryOperationCollectionResult<T> : RepositoryOperationBaseResult, IRepositoryOperationCollectionResult<T>
                                 where T : GatewayObject
    {
        public IReadOnlyCollection<T> Entities { get; internal set; }

      
    }

}
