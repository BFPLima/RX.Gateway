using RX.Gateway.Model.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Repository.Interface
{
    public interface IRepositoryOperationCollectionResult<T> : IRepositoryOperationBaseResult
                                 where T : GatewayObject
    {
        IReadOnlyCollection<T> Entities { get; }
    }

}
