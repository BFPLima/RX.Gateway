using RX.Gateway.Model.Core;

using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using RX.Gateway.Service.Interface;
using RX.Gateway.Repository.Interface;

namespace RX.Gateway.Service
{
    public abstract class ServiceBase<T> : IServiceBase<T> where T : GatewayObject
    {

        protected IRepositoryBase<T> repsositoryBase;

        public ServiceBase(IRepositoryBase<T> repsository)
        {
            this.repsositoryBase = repsository;
        }


        protected IServiceOperationResult<T> CopyResultFromService(IRepositoryOperationResult<T> repositoryOperationResult)
        {
            var result = new ServiceOperationResult<T>()
            {
                Entity = repositoryOperationResult.Entity,
                Message = repositoryOperationResult.Message,
                Tag = repositoryOperationResult.Tag,
                Exception = repositoryOperationResult.Exception,
                Status = repositoryOperationResult.Status
            };

            return result;
        }


        protected IServiceOperationCollectionResult<T> CopyResultCollecitonFromService(IRepositoryOperationCollectionResult<T> repositoryOperationResult)
        {
            var result = new ServiceOperationCollectionResult<T>()
            {
                Entities = repositoryOperationResult.Entities,
                Message = repositoryOperationResult.Message,
                Tag = repositoryOperationResult.Tag,
                Exception = repositoryOperationResult.Exception,
                Status = repositoryOperationResult.Status
            };

            return result;
        }



        public IServiceOperationResult<T> Delete(T entity)
        {
            var result = this.repsositoryBase.Delete(entity);
            return CopyResultFromService(result);
        }

        public IServiceOperationCollectionResult<T> GetAll()
        {
            var result = this.repsositoryBase.GetAll();
            return CopyResultCollecitonFromService(result);

        }

        public IServiceOperationResult<T> GetById(object id)
        {
            var result = this.repsositoryBase.GetById(id);
            return CopyResultFromService(result);
        }


        public IServiceOperationResult<T> Insert(T entity)
        {
            var result = this.repsositoryBase.Insert(entity);
            return CopyResultFromService(result);
        }


        public IServiceOperationResult<T> Update(T entity)
        {
            var result = this.repsositoryBase.Update(entity);
            return CopyResultFromService(result);
        }
    }
}
