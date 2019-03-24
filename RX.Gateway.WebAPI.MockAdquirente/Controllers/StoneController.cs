using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GatewayApiClient.DataContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RX.Gateway.WebAPI.MockThirdParty.Controllers
{
    [Produces("application/json")]
    [Route("v1/api/Acquiries/[controller]")]
    public class StoneController : MockController
    {


        [HttpPost]
        [Route("CreditCard")]
        public CreateSaleResponse Processa(CreateSaleRequest createSaleRequest)
        {
            Console.WriteLine("Requisição recebida : Stone CreditCard");

            return new CreateSaleResponse();
        }



    }
}