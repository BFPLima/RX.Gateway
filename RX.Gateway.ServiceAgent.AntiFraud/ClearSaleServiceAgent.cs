
using Newtonsoft.Json;
using RestSharp;
using RX.Gateway.Model.API.Request.AntiFraud.ClearSale;
using RX.Gateway.Model.API.Response.AntiFraud.ClearSale;
using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.ServiceAgent.AntiFraud
{
    public class ClearSaleServiceAgent : AntiFraudServiceAgentBase
    {

        public ResponseAuth Login(Credentials login)
        {
            var client = new RestClient("http://localhost:50976");

            var request = new RestRequest("/v1/api/AntiFraud/ClearSale/Login", Method.POST);

            var json = JsonConvert.SerializeObject(login);

            request.AddParameter("text/json", json, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            ResponseAuth responseAuth = null;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                try
                {
                    responseAuth = JsonConvert.DeserializeObject<ResponseAuth>(response.Content);
                }
                catch (Exception ex)
                {

                }
            }
            else
            {

            }

            return responseAuth;
        }

        public void Logout(Credentials login)
        {
            var client = new RestClient("http://localhost:50976");

            var request = new RestRequest("/v1/api/AntiFraud/ClearSale/Logout", Method.POST);

            var json = JsonConvert.SerializeObject(login);

            request.AddParameter("text/json", json, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

      

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                try
                {
                    
                }
                catch (Exception ex)
                {

                }
            }
            else
            {

            }

         
        }

        public ResponseSend Send(RequestSend requestSend)
        {
            var client = new RestClient("http://localhost:50976");

            var request = new RestRequest("/v1/api/AntiFraud/ClearSale/Send", Method.POST);

            var json = JsonConvert.SerializeObject(requestSend);

            request.AddParameter("text/json", json, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            ResponseSend responseSend = null;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                try
                {
                    responseSend = JsonConvert.DeserializeObject<ResponseSend>(response.Content);
                }
                catch (Exception ex)
                {

                }
            }
            else
            {

            }

            return responseSend;
        }
    }
}
