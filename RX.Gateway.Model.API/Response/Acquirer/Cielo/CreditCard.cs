using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Model.API.Response.Acquirer.Cielo
{

    public class CreditCard
    {
        public string CardNumber { get; set; }
        public string Holder { get; set; }
        public string ExpirationDate { get; set; }
        public bool SaveCard { get; set; }
        public string Brand { get; set; }
    }
}
