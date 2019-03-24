using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Model.Core
{
    public class StoreAntiFraud
    {

        public Guid StoreObjectID { get; set; }
        public Store Store { get; set; }

        public Guid AntiFraudObjectID { get; set; }
        public AntiFraud AntiFraud { get; set; }

    }
}
