using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RX.Gateway.Model.API.Request;
using RX.Gateway.Model.API.Request.AntiFraud.ClearSale;
using RX.Gateway.Model.API.Response;
using RX.Gateway.Model.API.Response.AntiFraud.ClearSale;
using RX.Gateway.Model.Core;
using RX.Gateway.Repository.EF;
using RX.Gateway.Repository.Interface;
using RX.Gateway.Service.Interface;
using RX.Gateway.ServiceAgent.Acquirier;
using RX.Gateway.ServiceAgent.AntiFraud;

namespace RX.Gateway.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("v1/api/[controller]")]
    public class GatewayController : Controller
    {


        private bool IsValuesCreditCardTransactionValid(RX.Gateway.Model.Transaction.CreditCardTransaction creditCardTransaction)
        {
            bool result = false;

            if (creditCardTransaction != null
                && creditCardTransaction.AmountInCents > 0
                && creditCardTransaction.Brand != Model.Enums.ECreditCardBrand.Undefined
                && String.IsNullOrEmpty(creditCardTransaction.CreditCardNumber)
                && creditCardTransaction.ExpMonth >= 1 && creditCardTransaction.ExpMonth <= 12
                && creditCardTransaction.ExpYear > 0
                && !string.IsNullOrEmpty(creditCardTransaction.HolderName)
                && creditCardTransaction.InstallmentCount >= 0
                && !string.IsNullOrEmpty(creditCardTransaction.SecurityCode)
                && creditCardTransaction.ShopkeeperId != null)
            {
                result = true;
            }


            return result;
        }



        [HttpPost]
        [Route("MakeCreditCardTransaction")]
        public TransactionResponse MakeCreditCardTransaction(
                [FromServices]RxGatewayDbContext dbContext,
                [FromServices]IUnityOfWork unityOfWork,
                [FromServices]IStoreService storeService,
                [FromServices] IAcquirierService acquirierService,
                [FromServices] IAntiFraudService antiFraudService,
                [FromServices]ICreditCardTransactionService creditCardTransactionService,
                [FromServices]IShopkeeperService shopkeeperService,

                [FromBody]CreditCardTransactionRequest transactionRequest)
        {



            if (transactionRequest == null)
            {
                return new TransactionResponse(null, Model.API.EStatusResponse.Error, "Transaction Request is null!");
            }

            if (IsValuesCreditCardTransactionValid(transactionRequest.Transaction))
            {
                return new TransactionResponse(null, Model.API.EStatusResponse.Error, "Some field of Trasaction request is invalid!");
            }


            RX.Gateway.Model.Transaction.CreditCardTransaction creditCardTransaction = transactionRequest.Transaction;


            var opResult = shopkeeperService.GetById(creditCardTransaction.ShopkeeperId);

            if (opResult == null || opResult.Status != Model.Enums.EOperationsStatus.Success && opResult.Entity == null)
            {
                return new TransactionResponse(null, Model.API.EStatusResponse.Error, "Shopkeeper is invalid!");
            }

            var shopkeeper = opResult.Entity as Shopkeeper;

            var acquirierByBrand = shopkeeper.AcquirierByBrand.Where(o => o.CreditCardBrand == creditCardTransaction.Brand).FirstOrDefault();

            if (acquirierByBrand == null)
            {
                return new TransactionResponse(null, Model.API.EStatusResponse.Error, "Não há adiquirente relacionado a bandeira : " + creditCardTransaction.Brand.ToString());
            }

            
            if (acquirierByBrand.Acquirier.Name == "Cielo")
            {
                #region Acquirer Cielo 


                CieloServiceAgent cieloServiceAgent = new CieloServiceAgent();

                Model.API.Request.Acquirer.Cielo.PaymentRequest paymentRequest = new Model.API.Request.Acquirer.Cielo.PaymentRequest();

                paymentRequest.MerchantOrderId = shopkeeper.ObjectID.ToString();
                paymentRequest.Customer = new Model.API.Request.Acquirer.Cielo.Customer()
                {
                    Name = shopkeeper.Name

                };

                paymentRequest.Payment = new RX.Gateway.Model.API.Request.Acquirer.Cielo.Payment()
                {
                    Type = "CreditCard",
                    Amount = Convert.ToInt32(creditCardTransaction.AmountInCents),
                    Installments = creditCardTransaction.InstallmentCount,
                    SoftDescriptor = creditCardTransaction.OrderNumber,
                    CreditCard = new Model.API.Request.Acquirer.Cielo.CreditCard()
                    {
                        CardNumber = creditCardTransaction.CreditCardNumber,
                        Holder = creditCardTransaction.HolderName,
                        ExpirationDate = string.Format("{0}/{1}", creditCardTransaction.ExpMonth, creditCardTransaction.ExpYear),
                        SecurityCode = creditCardTransaction.SecurityCode,
                        Brand = creditCardTransaction.Brand == Model.Enums.ECreditCardBrand.Visa ? "Visa" : "Master"
                    }
                };

                Model.API.Response.Acquirer.Cielo.PaymentResponse paymentResponse = cieloServiceAgent.MakeCreditCardTransaction(paymentRequest);


                #endregion
            }
            else if (acquirierByBrand.Acquirier.Name == "Stone")
            {
                #region Acquirer Stone

                GatewayApiClient.DataContracts.EnumTypes.CreditCardBrandEnum brand = GatewayApiClient.DataContracts.EnumTypes.CreditCardBrandEnum.Visa;

                switch (creditCardTransaction.Brand)
                {
                    case Model.Enums.ECreditCardBrand.Visa:
                        brand = GatewayApiClient.DataContracts.EnumTypes.CreditCardBrandEnum.Visa;
                        break;
                    case Model.Enums.ECreditCardBrand.Master:
                        brand = GatewayApiClient.DataContracts.EnumTypes.CreditCardBrandEnum.Mastercard;
                        break;
                }



                var transaction = new GatewayApiClient.DataContracts.CreditCardTransaction()
                {
                    AmountInCents = creditCardTransaction.AmountInCents,
                    CreditCard = new GatewayApiClient.DataContracts.CreditCard()
                    {
                        CreditCardBrand = brand,
                        CreditCardNumber = creditCardTransaction.CreditCardNumber,
                        ExpMonth = creditCardTransaction.ExpMonth,
                        ExpYear = creditCardTransaction.ExpYear,
                        HolderName = creditCardTransaction.HolderName,
                        SecurityCode = creditCardTransaction.SecurityCode
                    },
                    InstallmentCount = creditCardTransaction.InstallmentCount
                };

                // Cria requisição.
                var createSaleRequest = new GatewayApiClient.DataContracts.CreateSaleRequest()
                {
                    // Adiciona a transação na requisição.
                    CreditCardTransactionCollection = new System.Collections.ObjectModel.Collection<GatewayApiClient.DataContracts.CreditCardTransaction>(new GatewayApiClient.DataContracts.CreditCardTransaction[] { transaction }),
                    Order = new GatewayApiClient.DataContracts.Order()
                    {
                        OrderReference = creditCardTransaction.OrderNumber
                    }
                };


                StoneServiceAgent stoneServiceAgent = new StoneServiceAgent();

                var salesResponse = stoneServiceAgent.MakeCreditCardTransaction(createSaleRequest);



                #endregion
            }
            else
            {
                return new TransactionResponse(null, Model.API.EStatusResponse.Error, "Não há adiquirente relacionado a bandeira : " + creditCardTransaction.Brand.ToString());
            }

             

            //RxGatewayDbContext dbContext = new RxGatewayDbContext();
            // dbContext.InsertInitialData();


            //storeService.Insert(new Store()
            //{
            //    Name = "Eudora",
            //    ObjectID = System.Guid.NewGuid()
            //});

            unityOfWork.Salve();


            //db.Transactions.Add(transactionRequest.Transaction);
            //db.SaveChanges();
            //RxGatewayDbContext.InsertInitialData();



            //#region AntiFraud ClearSale

            //ClearSaleServiceAgent clearSaleServiceAgent = new ClearSaleServiceAgent();
            //Credentials login = new Credentials()
            //{
            //    Apikey = "",
            //    ClientID = "",
            //    ClientSecret = ""
            //};

            //ResponseAuth responseAuth = clearSaleServiceAgent.Login(login);

            //RequestSend requestSend = new RequestSend()
            //{
            //    ApiKey = login.Apikey,
            //    LoginToken = responseAuth.Token.Value,
            //    Orders = null,// orders
            //    AnalysisLocation = "BR"
            //};

            //ResponseSend responseSend = clearSaleServiceAgent.Send(requestSend);

            //clearSaleServiceAgent.Logout(login);

            //#endregion




            // Coloque a sua MerchantKey aqui.
            // Guid merchantKey = Guid.Parse("F2A1F485-CFD4-49F5-8862-0EBC438AE923");






            TransactionResponse transactionResponse = new TransactionResponse(null, Model.API.EStatusResponse.Success, "");


            return transactionResponse;

        }
    }
}