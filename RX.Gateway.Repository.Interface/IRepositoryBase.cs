using RX.Gateway.Model.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Repository.Interface
{
    public interface IRepositoryBase<T> where T : GatewayObject
    {
        IRepositoryOperationResult<T> Insert(T entity);

        IRepositoryOperationResult<T> Update(T entity); 

        IRepositoryOperationResult<T> Delete(T entity);

        IRepositoryOperationResult<T> GetById(object id);

        IRepositoryOperationCollectionResult<T> GetAll();
    }
}
