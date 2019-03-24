using RX.Gateway.Model.Core;
using RX.Gateway.Model.Transaction;
using RX.Gateway.Repository.EF;
using RX.Gateway.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Repository
{
    public class CreditCardTransactionRepository : RepositoryBase<CreditCardTransaction>, ICreditCardTransactionRepository
    {

        public CreditCardTransactionRepository(RxGatewayDbContext context)
          : base(context)
        {

        }
 
    }
}
