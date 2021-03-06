﻿using RX.Gateway.Model.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Repository.Interface
{
    public interface IRepositoryOperationResult<T> : IRepositoryOperationBaseResult
                 where T : GatewayObject
    {
        T Entity { get; }
    }


}
