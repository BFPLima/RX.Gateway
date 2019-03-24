using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RX.Gateway.Model.API.Request.AntiFraud.ClearSale;
using RX.Gateway.Model.API.Response.AntiFraud.ClearSale;

namespace RX.Gateway.WebAPI.MockThirdParty.Controllers
{
    [Produces("application/json")]
    [Route("v1/api/AntiFraud/[controller]")]
    public class ClearSaleController : Controller
    {

        [HttpPost]
        [Route("Login")]
        public ResponseAuth Login(Credentials credentials)
        {
            Console.WriteLine("Requisição recebida : ClearSale Login");

            ResponseAuth responseAuth = new ResponseAuth()
            {
                Token = new AuthToken()
                {
                    Value = System.Guid.NewGuid().ToString(),
                    ExpirationDate = DateTime.Now.AddHours(6).ToString("dd/MM/yyyy HH:mm:ss")
                }               
            };

            Console.WriteLine("  Simulando login...");

            return responseAuth;
        }

        [HttpPost]
        [Route("Logout")]
        public IActionResult Logout(Credentials credentials)
        {
            Console.WriteLine("Requisição recebida : ClearSale Logout");


            Console.WriteLine("  Simulando logout...");


            return Ok("Logout bem sucedido!");      
        }




        [HttpPost]
        [Route("Send")]
        public ResponseSend Send(RequestSend requestSend)
        {
            Console.WriteLine("Requisição recebida : ClearSale Send");


            Console.WriteLine("  Simulando análise antifraude ...");


            ResponseSend responseSend = new ResponseSend()
            {
                 
            };


            return responseSend;
        }
    }
}