using GatewayApiClient.DataContracts;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

using System.Text;


namespace RX.Gateway.ServiceAgent.Acquirier
{
    public class StoneServiceAgent : AcquirierServiceAgentBase
    {

        public CreateSaleResponse MakeCreditCardTransaction(CreateSaleRequest createSaleRequest)
        {
            var client = new RestClient("http://localhost:50976");

            var request = new RestRequest("/v1/api/Acquiries/Stone/CreditCard", Method.POST);

            var json = JsonConvert.SerializeObject(createSaleRequest);

            request.AddParameter("text/json", json, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);


            CreateSaleResponse createSaleResponse = null;



            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                try
                {
                    createSaleResponse = JsonConvert.DeserializeObject<CreateSaleResponse>(response.Content);
                }
                catch (Exception ex)
                { 

                }
            }
            else
            {
                 
            }

            return createSaleResponse;     


        }


    }
}
