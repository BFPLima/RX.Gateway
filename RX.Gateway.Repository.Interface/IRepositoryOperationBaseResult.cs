using RX.Gateway.Model.Core;
using RX.Gateway.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Repository.Interface
{
    public interface IRepositoryOperationBaseResult
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
