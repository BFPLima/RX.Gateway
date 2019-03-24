using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Model.Core
{
    public class Shopkeeper: GatewayObject
    {

        public string Name { get; set; }

        public IList<ShopkeeperAcquirierCredcardBrand> AcquirierByBrand { get; set; } = new List<ShopkeeperAcquirierCredcardBrand>();


        public Store Store { get; set; }
    }
}
