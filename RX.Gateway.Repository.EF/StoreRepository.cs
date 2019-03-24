using RX.Gateway.Model.Core;
using RX.Gateway.Repository.EF;
using RX.Gateway.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Repository
{
    public class StoreRepository : RepositoryBase<Store>, IStoreRepository
    {

        public StoreRepository(RxGatewayDbContext context)
            : base(context)
        {

        }


    }
}
