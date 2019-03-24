using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Model.API.Request.AntiFraud.ClearSale
{
    public class AuthToken
    {
        public string Value { get; set; } = string.Empty;
        public string ExpirationDate { get; set; } = string.Empty;
    }

}
