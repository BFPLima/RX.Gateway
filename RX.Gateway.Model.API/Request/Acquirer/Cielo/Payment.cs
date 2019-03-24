using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Model.API.Request.Acquirer.Cielo
{
    public class Payment
    {
        public string Type { get; set; }
        public int Amount { get; set; }
        public int Installments { get; set; }
        public string SoftDescriptor { get; set; }
        public CreditCard CreditCard { get; set; }
    }
}
