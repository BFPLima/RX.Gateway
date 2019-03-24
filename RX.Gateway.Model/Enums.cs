using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Model.Enums
{




    public enum ECreditCardBrand
    {
        Undefined = 0,
        Visa = 1,
        Master = 2
    }


    public enum ETrasactionStatus
    {
        Undefined = 0,
        Success = 1,
        Fail = 2,
        DeniedByAcquirier = 3,
        DeniedByAntifraud = 4
    }


    public enum EOperationsStatus
    {
        Undefined = 0,
        Success = 1,
        Fail = 2
    }


}
