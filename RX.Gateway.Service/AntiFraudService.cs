using RX.Gateway.Model.Core;
using RX.Gateway.Repository.Interface;
using RX.Gateway.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Service
{
    public class AntiFraudService : ServiceBase<AntiFraud>, IAntiFraudService
    {

        public AntiFraudService(IAntiFraudRepository repository)
            : base(repository)
        {

        }

    }
}
