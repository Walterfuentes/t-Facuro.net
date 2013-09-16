using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SOAPServices.Dominio
{   
    [DataContract]
    public class Factura
    {
        [DataMember]
        public int Numero { get; set; }
        [DataMember]
        public Cliente Cliente { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public decimal Total { get; set; }

    }
}