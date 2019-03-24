using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Model.API.Request.AntiFraud.ClearSale
{
    public class RequestSend : RequestBase
    {

        public string ApiKey { get; set; } = string.Empty;
        public string LoginToken { get; set; } = string.Empty;
        public List<Order> Orders { get; set; } = new List<Order>();
        public string AnalysisLocation { get; set; } = string.Empty;
        public bool Reanalysis { get; set; }
    }


    public class Order
    {
        public string ID { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Email { get; set; } = string.Empty;
        public int TotalItems { get; set; }
        public int TotalOrder { get; set; }
        public int TotalShipping { get; set; }
        public string IP { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public List<Payment> Payments { get; set; } = new List<Payment>();
        public BillingData BillingData { get; set; }
        public ShippingData ShippingData { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public string SessionID { get; set; } = string.Empty;
    }


    public class Payment
    {
        public string Date { get; set; } = string.Empty;
        public int Type { get; set; }
        public string CardNumber { get; set; } = string.Empty;
        public string CardHolderName { get; set; } = string.Empty;
        public string CardExpirationDate { get; set; } = string.Empty;
        public int Amount { get; set; }
        public int PaymentTypeID { get; set; }
        public int CardType { get; set; }
        public string CardBin { get; set; } = string.Empty;
    }


   

    public class Address
    {
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Comp { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string County { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
    }

    public class Phone
    {
        public int Type { get; set; }
        public int CountryCode { get; set; }
        public int AreaCode { get; set; }
        public string Number { get; set; } = string.Empty;
    }

    public class BillingData
    {
        public int ID { get; set; }
        public int Type { get; set; }
        public string BirthDate { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Address Address { get; set; }
        public List<Phone> Phones { get; set; } = new List<Phone>();
    }





    public class ShippingData
    {
        public int ID { get; set; }
        public int Type { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string BirthDate { get; set; } = string.Empty;
        public Address Address { get; set; }
        public List<Phone> Phones { get; set; } = new List<Phone>();
    }

    public class Item
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Category { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }

}
