using RX.Gateway.Model.Core;
using RX.Gateway.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Repository
{
    internal class RepositoryOperationResult<T> : RepositoryOperationBaseResult, IRepositoryOperationResult<T>
                                 where T : GatewayObject

    {
        public T Entity { get; internal set; }
    }


}
