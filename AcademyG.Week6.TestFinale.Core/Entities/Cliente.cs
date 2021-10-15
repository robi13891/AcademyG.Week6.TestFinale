using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AcademyG.Week6.TestFinale.Core.Entities
{
    [DataContract]
    public class Cliente
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CodiceCliente { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        public List<Ordine> Ordini { get; set; }
    }
}
