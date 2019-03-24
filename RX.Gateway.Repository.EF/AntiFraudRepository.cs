using RX.Gateway.Model.Core;
using RX.Gateway.Repository.EF;
using RX.Gateway.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Repository
{
    public class AntiFraudRepository : RepositoryBase<AntiFraud>, IAntiFraudRepository
    {

        public AntiFraudRepository(RxGatewayDbContext context)
          : base(context)
        {

        }
 
    }
}
