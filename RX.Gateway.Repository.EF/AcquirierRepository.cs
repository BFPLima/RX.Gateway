using RX.Gateway.Model.Core;
using RX.Gateway.Repository.EF;
using RX.Gateway.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Repository
{
    public class AcquirierRepository : RepositoryBase<Acquirier>, IAcquirierRepository
    {

        public AcquirierRepository(RxGatewayDbContext context)
            : base(context)
        {
          
        }
 
    }
}
