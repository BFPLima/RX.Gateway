using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Model.API.Response.AntiFraud.ClearSale
{
    public abstract class ClearSaleResponse : AntFraudResponse
    {
        public ClearSaleResponse(object entity, EStatusResponse status, string mensage)
          : base(entity, status, mensage)
        {


        }

    }
}
