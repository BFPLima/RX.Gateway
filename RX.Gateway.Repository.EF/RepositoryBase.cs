using RX.Gateway.Model.Core;
using RX.Gateway.Repository.EF;
using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using RX.Gateway.Model.Enums;
using RX.Gateway.Repository.Interface;

namespace RX.Gateway.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : GatewayObject
    {
        protected RxGatewayDbContext context = null;

        public RepositoryBase(RxGatewayDbContext context)
        {
            this.context = context;
        }




        public IRepositoryOperationResult<T> Delete(T entity)
        {
            IRepositoryOperationResult<T> result = null;

            try
            {
                var set = this.context.Set<T>();

                set.Remove(entity);

                result = new RepositoryOperationResult<T>()
                {
                    Entity = entity,
                    Status = EOperationsStatus.Success
                };
            }
            catch (Exception ex)
            {
                result = new RepositoryOperationResult<T>()
                {
                    Entity = entity,
                    Status = EOperationsStatus.Fail,
                    Exception = ex,
                    Message = ex.Message
                };
            }

            return result;
        }

        public IRepositoryOperationCollectionResult<T> GetAll()
        {
            RepositoryOperationCollectionResult<T> result = null;

            try
            {
                var set = this.context.Set<T>();
                result = new RepositoryOperationCollectionResult<T>()
                {
                    Entities = set.ToList<T>(),
                    Status = EOperationsStatus.Success
                };
            }
            catch (Exception ex)
            {
                result = new RepositoryOperationCollectionResult<T>()
                {
                    Status = EOperationsStatus.Fail,
                    Exception = ex,
                    Message = ex.Message
                };
            }

            return result;

        }

        public IRepositoryOperationResult<T> GetById(object id)
        {
            IRepositoryOperationResult<T> result = null;

            try
            {
                var set = this.context.Set<T>();

                T entity = set.Find(new object[] { id });

                result = new RepositoryOperationResult<T>()
                {
                    Entity = entity,
                    Status = EOperationsStatus.Success
                };
            }
            catch (Exception ex)
            {
                result = new RepositoryOperationResult<T>()
                {
                    Entity = null,
                    Status = EOperationsStatus.Fail,
                    Exception = ex,
                    Message = ex.Message
                };
            }

            return result;
        }


        public IRepositoryOperationResult<T> Insert(T entity)
        {
            IRepositoryOperationResult<T> result = null;

            try
            {
                var set = this.context.Set<T>();

                set.Add(entity);

                result = new RepositoryOperationResult<T>()
                {
                    Entity = entity,
                    Status = EOperationsStatus.Success
                };
            }
            catch (Exception ex)
            {
                result = new RepositoryOperationResult<T>()
                {
                    Entity = entity,
                    Status = EOperationsStatus.Fail,
                    Exception = ex,
                    Message = ex.Message
                };
            }

            return result;

        }


        public IRepositoryOperationResult<T> Update(T entity)
        {
            IRepositoryOperationResult<T> result = null;

            try
            {
                var set = this.context.Set<T>();

                set.Update(entity);

                result = new RepositoryOperationResult<T>()
                {
                    Entity = entity,
                    Status = EOperationsStatus.Success
                };
            }
            catch (Exception ex)
            {
                result = new RepositoryOperationResult<T>()
                {
                    Entity = entity,
                    Status = EOperationsStatus.Fail,
                    Exception = ex,
                    Message = ex.Message
                };
            }

            return result;

        }
    }
}
