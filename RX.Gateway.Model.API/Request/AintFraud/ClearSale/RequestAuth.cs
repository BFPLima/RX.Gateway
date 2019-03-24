using RX.Gateway.Model.API.Request.AntiFraud;
using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Model.API.Request.AntiFraud.ClearSale
{
    public class RequestAuth: AntiFraudRequest
    {

        public  Credentials Login { get; set; }

    }


}
