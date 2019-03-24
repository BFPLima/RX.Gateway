using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Model.API.Response.AntiFraud
{
    public abstract class AntFraudResponse : ResponseBase
    {
        public AntFraudResponse(object entity, EStatusResponse status, string mensage)
          : base(entity, status, mensage)
        {


        }

    }
}
