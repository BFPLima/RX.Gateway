using RX.Gateway.Model.Core;
using RX.Gateway.Model.Enums;
using RX.Gateway.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Service.Interface
{
    public interface IServiceOperationBaseResult
    {
        EOperationsStatus Status { get; }

        string Message { get; }

        Exception Exception { get; }

        /// <summary>
        /// Qualquer informação extra a ser transmitida
        /// </summary>
        Object Tag { get;   }
    }

  




}
