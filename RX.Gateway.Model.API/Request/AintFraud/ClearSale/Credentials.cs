using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Model.API.Request.AntiFraud.ClearSale
{
    public class Credentials
    {
        public string Apikey { get; set; } = string.Empty;
        public string ClientID { get; set; } = string.Empty;
        public string ClientSecret { get; set; } = string.Empty;
    }
}
