using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Model.API.Request.Acquirer.Cielo
{
    public class PaymentRequest
    {
        public string MerchantOrderId { get; set; }
        public Customer Customer { get; set; }
        public Payment Payment { get; set; }

       
    }
}
