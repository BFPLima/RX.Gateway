using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Model.API.Response
{
    public abstract class ResponseBase
    {
        protected ResponseBase(object entity, EStatusResponse status, string mensage)
        {
            this.Entity = entity;
            this.Status = status;
            this.Mensage = mensage;
        }

        public object Entity { get; protected set; }
        public EStatusResponse Status { get; protected set; } = EStatusResponse.Undefined;

        public string Mensage { get; set; } = string.Empty;

    }
}
