using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Client_WEB
{
    
    [ServiceContract]
    public interface IInserirPL
    {
        [OperationContract]
        void Insert(int m1, int m2, int m3, int m4, int m5, int user);
    }
}
