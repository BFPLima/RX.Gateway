using RX.Gateway.Model.Core;
using RX.Gateway.Model.Transaction;
using RX.Gateway.Repository.Interface;
using RX.Gateway.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Service
{
    public class CreditCardTransactionService : ServiceBase<CreditCardTransaction>, ICreditCardTransactionService
    {

        public CreditCardTransactionService(ICreditCardTransactionRepository repository)
            : base(repository)
        {

        }

    }
}
