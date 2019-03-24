using RX.Gateway.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RX.Gateway.Model.Core
{
    public class ShopkeeperAcquirierCredcardBrand
    {

        public Guid ShopkeeperID { get; set; }
        public Shopkeeper Shopkeeper { get; set; }

        public Guid AcquirierID { get; set; }
        public Acquirier Acquirier { get; set; }

       
        public ECreditCardBrand CreditCardBrand { get; set; }
         
    }
}
