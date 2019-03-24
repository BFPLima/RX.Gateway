using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RX.Gateway.Model.Core
{
    public abstract class GatewayObject
    {
        [Key]
        public Guid ObjectID { get; set; }
    }
}
