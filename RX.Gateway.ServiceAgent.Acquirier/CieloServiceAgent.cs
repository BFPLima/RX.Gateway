
using Newtonsoft.Json;
using RestSharp;
using RX.Gateway.Model.API.Request.Acquirer.Cielo;
using RX.Gateway.Model.API.Response.Acquirer.Cielo;
using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.ServiceAgent.Acquirier
{
    public class CieloServiceAgent : AcquirierServiceAgentBase
    {


        public PaymentResponse MakeCreditCardTransaction(PaymentRequest paymentRequest)
        {


            var client = new RestClient("http://localhost:50976");

            var request = new RestRequest("/v1/api/Acquiries/Cielo/Sales", Method.POST);

            var json = JsonConvert.SerializeObject(paymentRequest);

            request.AddParameter("text/json", json, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);


            PaymentResponse paymentResponse = null;



            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                try
                {
                    paymentResponse = JsonConvert.DeserializeObject<PaymentResponse>(response.Content);
                }
                catch (Exception ex)
                {

                }
            }
            else
            {

            }

            return paymentResponse;
        }

    }
}
