using RX.Gateway.Model.Core;
using RX.Gateway.Model.Enums;
using RX.Gateway.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Repository
{
    internal class RepositoryOperationBaseResult : IRepositoryOperationBaseResult
    {
        public EOperationsStatus Status { get; internal set; }

        public string Message { get; internal set; }

        public Exception Exception { get; internal set; }

        public object Tag { get; internal set; }
    }
}
