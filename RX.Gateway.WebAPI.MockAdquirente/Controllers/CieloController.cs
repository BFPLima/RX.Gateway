using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RX.Gateway.Model.API.Request.Acquirer.Cielo;
using RX.Gateway.Model.API.Response.Acquirer.Cielo;

namespace RX.Gateway.WebAPI.MockThirdParty.Controllers
{
    [Produces("application/json")]
    [Route("v1/api/Acquiries/[controller]")]
    public class CieloController : MockController
    {
 
        [HttpPost]
        [Route("Sales")]
        public PaymentResponse Processa(PaymentRequest paymentRequest)
        {
            Console.WriteLine("Requisição recebida : Cielo Sales");
 

            return new PaymentResponse();
        }

    }
}