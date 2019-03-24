using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Model.API.Response
{
    public class TransactionResponse : ResponseBase
    {
        public TransactionResponse(object entity, EStatusResponse status, string mensage)
            : base(entity, status, mensage)
        {

        }

    }
}
