using System;
using System.Collections.Generic;
using System.Text;
 


namespace RX.Gateway.Model.API.Request
{
    public class CreditCardTransactionRequest : RequestBase
    {
        public RX.Gateway.Model.Transaction.CreditCardTransaction Transaction { get; set; }

    }
}
