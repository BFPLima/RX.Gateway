using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Model.API.Response.AntiFraud.ClearSale
{
    public class ResponseSend
    {

        public List<Order> OrderStatus { get; set; }
        public string TransactionID { get; set; }
    }

    public class Order
    {
        public string ID { get; set; }
        public EOrderStatusResponse Status { get; set; }
        public double Score { get; set; }
    }
}
