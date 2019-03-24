using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Model.API.Response.Acquirer.Cielo
{
    public class PaymentResponse
    {
        public string MerchantOrderId { get; set; }
        public Customer Customer { get; set; }
        public Payment Payment { get; set; }
    }
}
