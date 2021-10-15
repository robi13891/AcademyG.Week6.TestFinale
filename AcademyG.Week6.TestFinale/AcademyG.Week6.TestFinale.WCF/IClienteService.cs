using AcademyG.Week6.TestFinale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AcademyG.Week6.TestFinale.WCF
{
    
    [ServiceContract]
    public interface IClienteService
    {
        [OperationContract]
        List<Cliente> GetAllClienti();

        [OperationContract]
        Cliente GetClienteById(int id);

        [OperationContract]
        bool AddCliente(Cliente cliente);

        [OperationContract]
        bool UpdateCliente(Cliente cliente);

        [OperationContract]
        bool DeleteClienteById(int id);

    }

}
