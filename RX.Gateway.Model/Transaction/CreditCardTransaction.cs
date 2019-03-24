using RX.Gateway.Model.Core;
using RX.Gateway.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RX.Gateway.Model.Transaction
{
    public class CreditCardTransaction : GatewayObject
    {    
        public Guid ShopkeeperId { get; set; }            

        [Column(TypeName = "varchar(200)")]
        public string CreditCardNumber { get; set; }

        public ECreditCardBrand Brand { get; set; }

        public int ExpMonth { get; set; }

        public int ExpYear { get; set; }

        public string HolderName { get; set; }

        [NotMapped]//Por motivos de segurança, não armazenar o securit code.
        public string SecurityCode { get; set; }

        public long AmountInCents { get; set; }

        public int InstallmentCount { get; set; }

        public string OrderNumber { get; set; }

    }

 
}
