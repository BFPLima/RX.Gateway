using System;
using System.Collections.Generic;
using System.Text;

namespace RX.Gateway.Repository.Interface
{
    public interface  IUnityOfWork
    {
        IUnitOfWortResult Salve();
    }
}
