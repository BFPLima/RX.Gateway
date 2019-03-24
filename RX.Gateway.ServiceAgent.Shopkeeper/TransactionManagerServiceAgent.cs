using Newtonsoft.Json;
using RestSharp;
using RX.Gateway.Model.API.Request;
using RX.Gateway.Model.API.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.ServiceAgent.Shopkeeper
{
    public class TransactionManagerServiceAgent
    {

        public TransactionResponse MakeCreditCardTransaction(CreditCardTransactionRequest transactionRequest)
        {

            var client = new RestClient("http://localhost:61337");

            var request = new RestRequest("/v1/api/Gateway/MakeCreditCardTransaction", Method.POST);

            var json = JsonConvert.SerializeObject(transactionRequest);

            request.AddParameter("text/json", json, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);


            TransactionResponse transactionResponse = null;



            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                try
                {
                    transactionResponse = JsonConvert.DeserializeObject<TransactionResponse>(response.Content);
                }
                catch (Exception ex)
                {

                }
            }
            else
            {

            }

            return transactionResponse;

        }

    }
}
