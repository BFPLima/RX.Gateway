using RX.Gateway.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RX.Gateway.Model.Transaction
{
    public class CreditCardTransactionRegistry : CreditCardTransaction
    {
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }

        public Guid AcquirierId { get; set; }

        public Guid AntiFraudId { get; set; }

        public ETrasactionStatus Status { get; set; } = ETrasactionStatus.Undefined;
    }
}
