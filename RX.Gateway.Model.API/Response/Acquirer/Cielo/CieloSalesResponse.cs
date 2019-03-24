using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Model.API.Response.Acquirer
{
    public class CieloSalesResponse : AcquirerResponse
    {

        public CieloSalesResponse(object entity, EStatusResponse status, string mensage)
            :base(entity,  status, mensage)
        {
           
           
        }

    }
}
