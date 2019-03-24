using Microsoft.EntityFrameworkCore;
using RX.Gateway.Model.Enums;
using RX.Gateway.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Repository.EF
{
    public class UnitOfWork : IUnityOfWork
    {
        protected RxGatewayDbContext context;

        public UnitOfWork(RxGatewayDbContext context)
        {
            this.context = context;
        }

        public IUnitOfWortResult Salve()
        {
            IUnitOfWortResult result = null;

            try
            {
                this.context.SaveChanges();
                result = new UnitOfWorkResult()
                {
                    Message = "Save ok",
                    Status = EOperationsStatus.Success
                };

            }
            catch (Exception ex)
            {
                result = new UnitOfWorkResult()
                {
                    Message = ex.Message,
                    Status = EOperationsStatus.Fail,
                    Exception = ex
                };
            }

            return result;
        }
    }
}
