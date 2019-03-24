using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Model.Core
{
    public class Store: GatewayObject
    {


        public string Name { get; set; }



        public virtual  IList<Shopkeeper> Shopkeepers { get; set; } = new List<Shopkeeper>();

        public virtual  IList<StoreAcquirier> Acquiriers { get; set; } = new List<StoreAcquirier>();

        public virtual  IList<StoreAntiFraud> AntiFrauds { get; set; } = new List<StoreAntiFraud>();


    }
}
