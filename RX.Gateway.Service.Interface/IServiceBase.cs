using RX.Gateway.Model.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Service.Interface
{
    public interface IServiceBase<T> where T : GatewayObject
    {
        IServiceOperationResult<T> Insert(T entity);

        IServiceOperationResult<T> Update(T entity);

        IServiceOperationResult<T> Delete(T entity);

        IServiceOperationResult<T> GetById(object id);

        IServiceOperationCollectionResult<T> GetAll();
    }
}
