using RX.Gateway.Model.API.Request;
using RX.Gateway.Model.Enums;
using RX.Gateway.Model.Transaction;
using RX.Gateway.ServiceAgent.Shopkeeper;
using System;

namespace RX.Gateway.Shopkeeper.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TransactionManagerServiceAgent transactionManagerServiceAgent = new TransactionManagerServiceAgent();


            var transactionId = System.Guid.NewGuid();

            CreditCardTransactionRequest transactionRequest = new CreditCardTransactionRequest()
            {
                Transaction = new RX.Gateway.Model.Transaction.CreditCardTransaction()
                {
                    ObjectID = transactionId,
                    AmountInCents = 10000,
                    InstallmentCount = 1,
                    //Date = DateTime.Now,


                    CreditCardNumber = "4111111111111111",
                    Brand = ECreditCardBrand.Visa,
                    ExpMonth = 10,
                    ExpYear = 22,
                    HolderName = "LUKE SKYWALKER",
                    SecurityCode = "123"

                }
            };


            transactionManagerServiceAgent.MakeCreditCardTransaction(transactionRequest);
        }
    }
}
