using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Model.Core
{
    public class StoreAcquirier
    {
        public Guid StoreObjectID { get; set; }
        public Store Store { get; set; }

        public Guid AcquirierObjectID { get; set; }
        public Acquirier Acquirier { get; set; }

    }
}
