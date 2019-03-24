using RX.Gateway.Model.Core;
using RX.Gateway.Repository.EF;
using RX.Gateway.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Repository
{
    public class ShopkeeperRepository : RepositoryBase<Shopkeeper>, IShopkeeperRepository
    {
        public ShopkeeperRepository(RxGatewayDbContext context)
           : base(context)
        {

        }

     
  
    }
}
